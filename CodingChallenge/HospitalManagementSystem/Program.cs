using HospitalManagementSystem.Model;
using HospitalManagementSystem.Service;

namespace HospitalManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPatientService _patientService = new PatientService();
            IDoctorService _doctorService = new DoctorService();
            IHospitalService _hospitalService = new HospitalService();

            bool con = true;
            try
            {

                while (con)
                {
                    Console.WriteLine("Enter 1 for Doctor Service");
                    Console.WriteLine("Enter 2 for Patient Service");
                    Console.WriteLine("Enter 3 for Hosipital Management Service");
                    Console.WriteLine("Enter 0 for Exit()");
                    int input = int.Parse(Console.ReadLine());
                    switch (input)
                    {
                        case 1:
                            Console.WriteLine("Enter 1 for Adding New Doctor");
                            Console.WriteLine("Enter 2 for Getting All Doctors Information");
                            Console.WriteLine("Enter 3 for Updating  Doctor");
                            Console.WriteLine("Enter 4 for Deleting a Doctor");
                            int doctorinput = int.Parse(Console.ReadLine());
                            switch (doctorinput)
                            {
                                case 1:
                                    Console.WriteLine(_doctorService.CreateDoctor());
                                    break;
                                case 2:
                                    PrintingService.GetAllDoctors();
                                    break;
                                case 3:
                                    Console.WriteLine(_doctorService.UpdateDoctor());
                                    break;
                                case 4:
                                    Console.WriteLine(_doctorService.DeleteDoctor());
                                    break;
                                default:
                                    Console.WriteLine("Wrong Choice");
                                    break;
                            }
                            break;
                        case 2:
                            Console.WriteLine("Enter 1 for Adding New Patient");
                            Console.WriteLine("Enter 2 for Getting All Patient Information");
                            Console.WriteLine("Enter 3 for Updating  Patient");
                            Console.WriteLine("Enter 4 for Deleting a Patient");
                            int patientinput = int.Parse(Console.ReadLine());
                            switch (patientinput)
                            {
                                case 1:
                                    Console.WriteLine(_patientService.CreatePatient());
                                    break;
                                case 2:
                                    PrintingService.GetAllPatients();
                                    break;
                                case 3:
                                    Console.WriteLine(_patientService.UpdatePatient());
                                    break;
                                case 4:
                                    Console.WriteLine(_patientService.DeletePatient());
                                    break;
                                default:
                                    Console.WriteLine("Wrong Choice");
                                    break;
                            }
                            break;
                        case 3:
                            Console.WriteLine("Enter 1 for Getting Appointment Details by AppointmentId");
                            Console.WriteLine("Enter 2 for Getting Appointment Details for a specific Patient");
                            Console.WriteLine("Enter 3 for Getting Appointment Details for a specific Doctor");
                            Console.WriteLine("Enter 4 for Scheduling an Appointment");
                            Console.WriteLine("Enter 5 for Updating Appointment details");
                            Console.WriteLine("Enter 6 for Cancelling Appointment");
                            int appointmentinput = int.Parse(Console.ReadLine());
                            switch (appointmentinput)
                            {
                                case 1:
                                    PrintingService.GetAppointmentById();
                                    break;
                                case 2:
                                    PrintingService.GetAppointmentsForPatient();
                                    break;
                                case 3:
                                    PrintingService.GetAppointmentsForDoctor();
                                    break;
                                case 4:
                                    Console.WriteLine(_hospitalService.ScheduleAppointment());
                                    break;
                                case 5:
                                    Console.WriteLine(_hospitalService.UpdateAppointment);
                                    break;
                                case 6:
                                    Console.WriteLine(_hospitalService.CancelAppointment());
                                    break;
                                default:
                                    Console.WriteLine("Wrong choice");
                                    break;
                            }
                            break;
                        case 0:
                            con = false;
                            break;
                        default:
                            Console.WriteLine("Wrong Choice");
                            break;
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
