namespace MVCProject.PL.Notes
{
    public class Notes
    {
        #region MVC03
        // if you install package in DAl and you want to Pl see that you must build the project
        //First we must divide it to services 
        //AFTER THAT we will code the Data Access layer
        //Data file contain migration + Configuration + dbContext 
        #endregion

        #region MVC04

        #region Interface For Repository

        // in MVC we work with 3 layer architecture 
        // in Business logic layer we work with repository design pattern or unit of work
        // repository design pattern have to type with and without generic
        // Generic used to reduce repetition
        // interfaces in onion architecture is in core(domain) layer
        // interfaces in 3 tier architecture is in business logic layer
        // in repository folder each model will create repository for him (5 action)
        // we make interface(code contract = action inside repository) for each repository 
        //من خلال الانترفيس بنحدد شكل الريبوزتري بحيث لو اكتر من داتا بيز 
        //و عندي اكتر من ريبو لنفس الموديل  يبقي ليهم نفس الميثود 
        // implement against interface not against concrete class
        #endregion

        #region Dependency Injection
        // DepartmentRepository علشان اكريت اوبجيكت من ال 
        // CLR فا ال  AppDbContext معتمد علي حقن اوبجيكت من ال
        // AppDbContext هيروح الستارت اب يشوف انت عامل ريجيستر للسيرفيس بتاعت ال
        //  فا هيروح يكريت اوبجيكت منه عن طريق البرامتر ليس كونستراكتور 
        // DbContext الي بيتشين علي الكونستراكتور بتاع البيز 
        // البرامتر ليس بتاع البيز بيعمل تشين علي كونستراكتور بياخد برامتر من نوع
        // onconfigring الي من جواه بينفز ال   DbContextOptions
        // الداتا بيز استرينج onconfigring الي موجود في optionsBuilder بنبعت عن طريق ال 

        // بدل ما نعمل تشين علي الكونستراكتور بتاع البيز 
        // هنعمل اتشين علي البرامتاريزد علي طول 
        #endregion


        #region Migration
        // we need apply migration after doing model and other
        // we install package tool in PL that i will run migration on it (project have app setting)
        // make PL is the start up project 
        // we add migration folder on DAL 
        //Add-Migration "initialCreate" -context AppDbContext          -output Data/Migration 
        //               name of mig    -DbContext that will connect  - folder that will add mig

        #endregion

        #region Presentation Layer (MVC Project)
        //Assembly reference from another solution
        //project reference from same solution
        //launchBrowser": true after deploy open browser
        //windowsAuthentication true no one will access app unless user in server

        #endregion

        #endregion

    }
}
