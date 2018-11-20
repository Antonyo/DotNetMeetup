using DotNetMeetup.Blazor.Client.Services;
using DotNetMeetup.Blazor.Shared.Models;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DotNetMeetup.Blazor.Client.PageBases
{
    public class UsersBase : BlazorComponent, IDisposable
    {
        [Inject] public AppState State { get; set; } // This service is injected as singleton

        protected override async Task OnInitAsync()
        {
            State.OnUsersChanged += StateHasChanged; // This will make the component re render when the user list have changed
            await State.LoadUsers();
        }

        public async Task DeleteUserAsync(User user) => await State.DeleteUser(user);

        public async Task AddUserAsync(User user) => await State.AddUser(user);

        /// <summary>
        /// Dispose method will be called when the component is removed from the UI
        /// </summary>
        public void Dispose()
        {

        }
    }
}
