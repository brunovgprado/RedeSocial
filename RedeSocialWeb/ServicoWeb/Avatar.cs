using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedeSocialWeb.ServicoWeb
{
    public class Avatar
    {
        const string AVATAR_1 = "https://raw.githubusercontent.com/brunovitorprado/RedeSocial/master/avatar1.png";
        const string AVATAR_2 = "https://raw.githubusercontent.com/brunovitorprado/RedeSocial/master/avatar2.png";
        const string AVATAR_3 = "https://raw.githubusercontent.com/brunovitorprado/RedeSocial/master/avatar3.png";


        public static string GetAvatar()
        {
            var SegundoAtual = DateTime.Now.Second;

            if (SegundoAtual < 20)
            {
                return AVATAR_1;
            }else
            {
                if (SegundoAtual >= 20 && SegundoAtual < 40)
                    return AVATAR_2;
            }
            return AVATAR_3;
        }
    }
}