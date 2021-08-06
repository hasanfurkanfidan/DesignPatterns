using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Template.UserCards
{
    public class DefaultUserCardTemplate:UserCardTemplate
    {
        protected override string SetFooter()
        {
            throw new NotImplementedException();
        }
        protected override string SetPicture()
        {
            return $"  <img src='/img/index.png' class='card - img - top''>";
        }
    }
}
