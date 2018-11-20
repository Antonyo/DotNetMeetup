using DotNetMeetup.Blazor.Shared.Models;
using Microsoft.AspNetCore.Blazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DotNetMeetup.Blazor.Client.Services
{
    public class AppState
    {
        private readonly List<User> _users = new List<User>();
        public IReadOnlyList<User> Users => _users;

        private readonly List<Meetup> _meetups = new List<Meetup>();
        public IReadOnlyList<Meetup> Meetups => _meetups;

        public Meetup SelectedMeetup { get; private set; }

        public bool UsersLoaded { get; private set; } = false;
        public bool MeetupsLoaded { get; private set; } = false;

        public event Action OnUsersChanged;
        public event Action OnMeetupsChanged;
        public event Action OnSelectedMeetupChanged;

        private readonly HttpClient _http; // This service is injected as singleton
        public AppState(HttpClient http)
        {
            _http = http;
        }

        public async Task LoadUsers()
        {
            if (UsersLoaded)
                return;

            _users.AddRange(await _http.GetJsonAsync<IEnumerable<User>>("api/users"));
            UsersLoaded = true;
        }

        public async Task LoadMeetups()
        {
            if (MeetupsLoaded)
                return;

            _meetups.AddRange(await _http.GetJsonAsync<IEnumerable<Meetup>>("api/meetups"));
            MeetupsLoaded = true;

            OnMeetupsChanged?.Invoke();
            SelectMeetup();
        }

        public async Task DeleteUser (User user)
        {
            if (!UsersLoaded)
                return;

            _users.Remove(user);
            await _http.DeleteAsync($"api/users/{user.Id}");

            OnUsersChanged?.Invoke();
        }

        public async Task AddUser(User user)
        {
            if (!UsersLoaded)
                return;

            var createdUser = await _http.PostJsonAsync<User>($"api/users/", user);
            _users.Add(createdUser);

            OnUsersChanged?.Invoke();
        }

        public void SelectMeetup(long? id = null)
        {
            if (!MeetupsLoaded)
                return;

            SelectedMeetup = id.HasValue? _meetups.FirstOrDefault(x => x.Id == id) : _meetups.FirstOrDefault();

            OnSelectedMeetupChanged?.Invoke();
        }

        public async Task AddAttendee(Meetup meetup, User user, bool willAttend)
        {
            var localAttendee = meetup.Attendees.FirstOrDefault(x => x.UserId == user.Id);
            if(localAttendee == null)
            {
                localAttendee = new Attendee
                {
                    MeetupId = meetup.Id,
                    UserId = user.Id,
                    WillAttend = willAttend
                };

                meetup.Attendees.Add(localAttendee);
            }
            else
                localAttendee.WillAttend = willAttend;

            await _http.PutJsonAsync<Attendee>($"api/attendees/", localAttendee);

            OnSelectedMeetupChanged?.Invoke();
        }

        public int IndexOf(User user)
        {
            return _users.IndexOf(user);
        }
    }
}
