using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Template.Entities;

namespace WebApp.Template.UserCards
{
    public abstract class UserCardTemplate
    {
        protected AppUser appUser { get; set; }
        public void SetUser(AppUser user)
        {
            appUser = user;
        }
        public string Build()
        {
            if (appUser == null) throw new ArgumentNullException(nameof(AppUser));

            var sb = new StringBuilder();

            sb.Append("<div class='card'>");
            sb.Append(SetPicture());
            sb.Append($@"<div class='card-body'>
                          <h5>{appUser.UserName}</h5>
                          <p>{appUser.Description}</p>");
            sb.Append(SetFooter());
            sb.Append("</div>");
            sb.Append("</div>");

            return sb.ToString();
        }
        protected abstract string SetFooter();

        protected abstract string SetPicture();


    }
}
