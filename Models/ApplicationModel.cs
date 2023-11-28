using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O_neilloGame.Models
{
    public class ApplicationModel
    {
        public SettingsServiceModel Settings;
        public List<GameServiceModel> Games;

        public ApplicationModel() { }
        public ApplicationModel(SettingsServiceModel settings, List<GameServiceModel> games) 
        {
            Settings = settings;
            Games = games;
        }

    }
}
