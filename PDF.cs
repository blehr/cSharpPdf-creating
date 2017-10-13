using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace LOWN
{
    public class PDF
    {
        public virtual void CreatePdf(string dest)
        {
            var titleFont = FontFactory.GetFont("Arial", 12, Font.BOLD);
            var sectionHeaderFont = FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.WHITE);
            var endingMessageFont = FontFactory.GetFont("Arial", 6, Font.NORMAL);
            var bodyFont = FontFactory.GetFont("Arial", 8, Font.NORMAL);

            Document document = new Document();
            PdfWriter.GetInstance(document, new FileStream(dest, FileMode.Create));
            document.Open();

            PdfPTable table = new PdfPTable(3);

            table.DefaultCell.PaddingBottom = 10;

            PdfPCell title = new PdfPCell(new Phrase("PERSCRIPTION DRUG PRIOR AUTHORIZATION REQUEST FORM", titleFont));
            title.Colspan = 3;
            title.HorizontalAlignment = 1;
            title.Border = 0;
            title.PaddingBottom = 10;
            table.AddCell(title);

            PdfPCell description = new PdfPCell(new Phrase("Instructions: The Workers’ Compensation insurance carrier handling the below injury is requesting a summary of medical necessity from the treating physician describing how medication is related to the injury. Please note that failure to respond to this request may result in the denial of coverage for the medication.  You may attach any additional documentation that is important for the review, e.g. chart notes or lab data, to support this request.", bodyFont));
            description.Colspan = 3;
            table.AddCell(description);

            PdfPCell patientInfo = new PdfPCell(new Phrase("Patient Information", sectionHeaderFont));
            patientInfo.Colspan = 3;
            patientInfo.BackgroundColor = new BaseColor(0, 0, 0);
            table.AddCell(patientInfo);

            PdfPCell name = new PdfPCell(new Phrase("Name: ", bodyFont));
            name.Colspan = 3;
            name.PaddingBottom = 10;
            table.AddCell(name);

            table.AddCell(new Phrase("Date of Birth: ", bodyFont));
            table.AddCell(new Phrase("Gender: ", bodyFont));
            table.AddCell(new Phrase("Phone: ", bodyFont));

            PdfPCell address = new PdfPCell(new Phrase("Address: ", bodyFont));
            address.Colspan = 3;
            address.PaddingBottom = 10;
            table.AddCell(address);

            table.AddCell(new Phrase("City: ", bodyFont));
            table.AddCell(new Phrase("State: ", bodyFont));
            table.AddCell(new Phrase("Zipcode: ", bodyFont));

            PdfPCell workersCompClaim = new PdfPCell(new Phrase("Worker’s Compensation Claim Information", sectionHeaderFont));
            workersCompClaim.Colspan = 3;
            workersCompClaim.BackgroundColor = new BaseColor(0, 0, 0);
            table.AddCell(workersCompClaim);

            PdfPCell insuranceCarrier = new PdfPCell(new Phrase("Insurance Carrier: ", bodyFont));
            insuranceCarrier.Colspan = 3;
            insuranceCarrier.PaddingBottom = 10;
            table.AddCell(insuranceCarrier);

            PdfPCell employer = new PdfPCell(new Phrase("Employer: ", bodyFont));
            employer.Colspan = 3;
            employer.PaddingBottom = 10;
            table.AddCell(employer);

            table.AddCell(new Phrase("DOI: ", bodyFont));
            table.AddCell(new Phrase("Claim#: ", bodyFont));
            table.AddCell(new Phrase("ICD10: ", bodyFont));

            PdfPCell providerInfo = new PdfPCell(new Phrase("Provider Information", sectionHeaderFont));
            providerInfo.Colspan = 3;
            providerInfo.BackgroundColor = new BaseColor(0, 0, 0);
            table.AddCell(providerInfo);

            PdfPCell providerName = new PdfPCell(new Phrase("Provider's Name: ", bodyFont));
            providerName.Colspan = 2;
            providerName.PaddingBottom = 10;
            table.AddCell(providerName);
           
            PdfPCell providerId = new PdfPCell(new Phrase("Provider Id Number: ", bodyFont));
            providerId.Colspan = 2;
            providerId.PaddingBottom = 10;
            table.AddCell(providerId);
            
            PdfPCell providerPhone = new PdfPCell(new Phrase("Phone: ", bodyFont));
            providerPhone.Colspan = 2;
            providerPhone.PaddingBottom = 10;
            table.AddCell(providerPhone);
            
            PdfPCell providerFax = new PdfPCell(new Phrase("Fax: ", bodyFont));
            providerFax.Colspan = 2;
            providerFax.PaddingBottom = 10;
            table.AddCell(providerFax);

            PdfPCell medInfo = new PdfPCell(new Phrase("Medication Information", sectionHeaderFont));
            medInfo.Colspan = 3;
            medInfo.BackgroundColor = new BaseColor(0, 0, 0);
            table.AddCell(medInfo);

            PdfPCell medName = new PdfPCell(new Phrase("Medication Name/Strength: ", bodyFont));
            medName.Colspan = 2;
            medName.PaddingBottom = 10;
            table.AddCell(medName);

            table.AddCell(new Phrase("#Refills: ", bodyFont));
            table.AddCell(new Phrase("Qty:      Day Supply:   ", bodyFont));

            PdfPCell therapy = new PdfPCell(new Phrase("Therapy: ", bodyFont));
            therapy.Colspan = 2;
            therapy.PaddingBottom = 10;
            table.AddCell(therapy);

            PdfPCell prescribedIndication = new PdfPCell(new Phrase("Prescribed Indication: ", bodyFont));
            prescribedIndication.Colspan = 3;
            prescribedIndication.Rowspan = 2;
            prescribedIndication.PaddingBottom = 20;
            table.AddCell(prescribedIndication);

            PdfPCell divider = new PdfPCell(new Phrase("Signature", sectionHeaderFont));
            divider.Colspan = 3;
            divider.BackgroundColor = new BaseColor(0, 0, 0);
            table.AddCell(divider);

            PdfPCell prescriberSignature = new PdfPCell(new Phrase("Prescriber Signature: ", bodyFont));
            prescriberSignature.Colspan = 2;
            prescriberSignature.PaddingBottom = 10;
            table.AddCell(prescriberSignature);

            table.AddCell(new Phrase("Date: ", bodyFont));

            PdfPCell confidentiality = new PdfPCell(new Phrase("Confidentiality Notice: The documents accompanying this transmission contain confidential health information that is legally privileged. If you are not the intended recipient, you are hereby notified that any disclosure, copying, distribution, or action taken in reliance on the contents of these documents is strictly prohibited. If you have received this information in error, please notify the sender immediately and arrange for the return or destruction of these documents.", endingMessageFont));
            confidentiality.Colspan = 3;
            table.AddCell(confidentiality);

            document.Add(table);
            document.Close();
        }
    }
}