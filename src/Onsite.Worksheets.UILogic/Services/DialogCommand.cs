using System;

namespace Onsite.Worksheets.UILogic.Services
{
    public class DialogCommand
    {
        public object Id { get; set; }
        public string Label { get; set; }
        public Action Invoked { get; set; }
    }
}
