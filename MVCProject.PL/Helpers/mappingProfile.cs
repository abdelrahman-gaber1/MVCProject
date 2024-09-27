using AutoMapper;
using MVCProject.DAL.Models;
using MVCProject.PL.ViewModels;

namespace MVCProject.PL.Helpers
{
    public class mappingProfile : Profile
    {
        //I need when any one will create object form this class learn him how to mapping
        public mappingProfile()
        {
            //method inherited from profile that till i will convert form what to what
            CreateMap<EmployeeViewModel, Employee>().ReverseMap().ForMember(d => d.Name, o => o.MapFrom(s => s.Name));
            //                                                 destination(model)         source(ViewModel)
            //if the name of property in model different from his name in view model he can't convert
            //so i must learn him how to convert it 

            //note if the name of property in employee is ImageName and in EmployeeViewModel Image he can't map automatically
            //will make exception so we must add property in EmployeeViewModel called ImageName so he can map
        }
    }
}
