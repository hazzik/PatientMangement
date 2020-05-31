using System;
using PatientManagement.AdmissionDischargeTransfer;

namespace ProjectionManager
{
    internal class WardViewProjection : Projection
    {
        public WardViewProjection(ConnectionFactory connectionFactory)
        {
            When<PatientAdmitted>((e, p) =>
            {
                Console.WriteLine($"Recording Patient Admission: {e.PatientName}");
                return new Patient
                {
                    Id = e.PatientId,
                    WardNumber = e.WardNumber,
                    PatientName = e.PatientName,
                    AgeInYears = e.AgeInYears
                };
            });

            When<PatientTransfered>((e, p) =>
            {
                Console.WriteLine($"Recording Patient Transfer: {e.PatientId}");
                return new Patient(p)
                {
                    WardNumber = e.WardNumber
                };
            });

            When<PatientDischarged>((e, p) =>
            {
                Console.WriteLine($"Recording Patient Discharged: {e.PatientId}");
                return null;
            });
        }
    }

    public class Patient
    {
        public Patient()
        {
        }
        
        public Patient(Patient p)
        {
            Id = p.Id;
            WardNumber = p.WardNumber;
            PatientName = p.PatientName;
            AgeInYears = p.AgeInYears;
        }
        
        public Guid Id { get; set; }

        public int WardNumber { get; set; }

        public string PatientName { get; set; }

        public int AgeInYears { get; set; }
    }
}
