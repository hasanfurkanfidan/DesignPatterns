using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Template.UserCards
{
    public class DefaultUserCardTemplate:UserCardTemplate
    {
        protected override string SetFooter()
        {

            return string.Empty;
        }
        protected override string SetPicture()
        {
            return $"  <img src='/img/index.png' class='card - img - top''>";
        }
    }
}
