using DotNetMeetup.Blazor.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetMeetup.Blazor.Data
{
    public static class DatabaseSeeder
    {
        public static void Seed(AppDataContext dataContext)
        {
            var users = new List<User>()
            {
                new User { Name = "Harry Dean Stanton", Email = "harrydeanstanton@outluck.com" },
                new User { Name = "Tom Skerritt", Email = "tomskerritt@outluck.com" },
                new User { Name = "Michael Biehn" },
                new User { Name = "Sigourney Weaver", Email = "sigourneyweaver@liamg.com" },
                new User { Name = "Veronica Cartwright", Email = "veronicacartwright@hayoo.com" },
                new User { Name = "John Hurt", Email = "johnhurt@outluck.com" },
                new User { Name = "Ian Holm", Email = "ianholm@liamg.com" },
                new User { Name = "Paul Reiser" },
                new User { Name = "Yaphet Kotto", Email = "yaphetkotto@outluck.com" },
                new User { Name = "Helen Horton", Email = "helenhorton@hayoo.com" },
                new User { Name = "Lance Henriksen", Email = "bishop@outluck.com" },
                new User { Name = "William Hope", Email = "williamhope@hayoo.com" }
            };

            dataContext.AddRange(users);

            var meetups = new List<Meetup>
            {
                new Meetup { Name = "Tokyo .NET Developers Meetup #39", Date = new DateTime(2018, 11, 20, 19, 00, 00), Location = "Microsoft Shinagawa 31F VIP Board Room" },
                new Meetup { Name = "Tokyo .NET Developers Meetup #38", Date = new DateTime(2018, 10, 23, 19, 00, 00), Location = "Microsoft Shinagawa 31F VIP Board Room" },
                new Meetup { Name = "Tokyo .NET Developers Meetup #37", Date = new DateTime(2018, 9, 18, 19, 00, 00), Location = "Microsoft Shinagawa 31F VIP Board Room" },
                new Meetup { Name = "Tokyo .NET Developers Meetup #36", Date = new DateTime(2018, 8, 28, 19, 00, 00), Location = "Microsoft Shinagawa 31F VIP Board Room" },
                new Meetup { Name = "Tokyo .NET Developers Meetup #35", Date = new DateTime(2018, 7, 31, 19, 00, 00), Location = "Microsoft Shinagawa 31F VIP Board Room" },
                new Meetup { Name = "Tokyo .NET Developers Meetup #34", Date = new DateTime(2018, 6, 26, 19, 00, 00), Location = "Microsoft Shinagawa 31F VIP Board Room" },
                new Meetup { Name = "Tokyo .NET Developers Meetup #33", Date = new DateTime(2018, 5, 29, 19, 00, 00), Location = "Microsoft Shinagawa 31F VIP Board Room" },
                new Meetup { Name = "Tokyo .NET Developers Meetup #32", Date = new DateTime(2018, 4, 17, 19, 00, 00), Location = "Microsoft Shinagawa 31F VIP Board Room" }
            };

            dataContext.AddRange(meetups);

            dataContext.Add(new Attendee { MeetupId = meetups[0].Id, UserId = users[0].Id, WillAttend = true });
            dataContext.Add(new Attendee { MeetupId = meetups[0].Id, UserId = users[1].Id, WillAttend = false });
            dataContext.Add(new Attendee { MeetupId = meetups[1].Id, UserId = users[5].Id, WillAttend = true });
            dataContext.Add(new Attendee { MeetupId = meetups[2].Id, UserId = users[3].Id, WillAttend = true });
            dataContext.Add(new Attendee { MeetupId = meetups[3].Id, UserId = users[0].Id, WillAttend = false });

            dataContext.SaveChanges();
        }
    }
}
