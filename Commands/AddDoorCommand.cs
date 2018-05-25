using Rocket.API;
using Rocket.Unturned.Chat;
using SDG.Unturned;
using System.Collections.Generic;

namespace DoorPlugin
{
    public class AddDoorCommand : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "AddDoor";

        public string Help => "/AddDoor";

        public string Syntax => "";

        public List<string> Aliases => new List<string> { "adddoor", "AD" };

        public List<string> Permissions => new List<string> { "D.Adddoor" };

        public void Execute(IRocketPlayer caller, string[] command)
        {
            var raycast = DoorPlugin.Raycast(caller);
            if(raycast != null)
            {
                if (raycast.GetComponent<InteractableDoorHinge>() != null)
                {
                    DoorPlugin.Instance.Configuration.Instance.SaveData(raycast.parent.parent, command, caller);
                    string Permissions = "";
                    foreach (var item in command)
                    {
                        Permissions += item + ", ";
                    }
                    UnturnedChat.Say(caller, DoorPlugin.Instance.Translations.Instance.Translate("DoorAdded") + Permissions);
                }
                else
                {
                    UnturnedChat.Say(caller, DoorPlugin.Instance.Translations.Instance.Translate("NoDoor"), UnityEngine.Color.red);
                }

            }   
        }
    }
}
