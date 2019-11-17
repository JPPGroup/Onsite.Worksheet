using Onsite.Worksheets.UILogic.Abstracts;
using Onsite.Worksheets.UILogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace Onsite.Worksheets.Services
{
    public class AlertMessageService : IAlertMessageService
    {
        private static bool _isShowing;

        public async Task ShowAsync(string message, string title)
        {
            await ShowAsync(message, title, null);
        }

        public async Task ShowAsync(string message, string title, IEnumerable<DialogCommand> dialogCommands)
        {
            if (!_isShowing) // Only show one dialog at a time.
            {
                var messageDialog = new MessageDialog(message, title);
                if (dialogCommands != null)
                {
                    var commands = dialogCommands.Select(c => new UICommand(c.Label, (command) => c.Invoked(), c.Id));
                    foreach (var command in commands)
                    {
                        messageDialog.Commands.Add(command);
                    }
                }

                _isShowing = true;
                await messageDialog.ShowAsync();
                _isShowing = false;
            }
        }
    }
}
