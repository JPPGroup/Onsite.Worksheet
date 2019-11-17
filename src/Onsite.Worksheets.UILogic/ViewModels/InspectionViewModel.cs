using System;
using Onsite.Worksheets.UILogic.Abstracts;
using Onsite.Worksheets.UILogic.Models;
using Prism.Windows.AppModel;

namespace Onsite.Worksheets.UILogic.ViewModels
{
    public class InspectionViewModel
    {
        private Inspection _inspection;
        private readonly IInspectionRepository _inspectionRepository;
        private readonly IAlertMessageService _alertMessageService;
        private readonly IResourceLoader _resourceLoader;

        public InspectionViewModel(Inspection inspection, IInspectionRepository inspectionRepository, IAlertMessageService alertMessageService, IResourceLoader resourceLoader)
        {
            _inspection = inspection ?? throw new ArgumentNullException(nameof(inspection));
            _inspectionRepository = inspectionRepository;
            _alertMessageService = alertMessageService;
            _resourceLoader = resourceLoader;
        }
    }
}