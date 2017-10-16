using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace LOWN
{
    public class PDF
    {
        public PDF(Person person)
        {
            Person = person;
        }

        public Person Person { get; }

        public PdfPCell CreateCustomCell(int numberOfCol, Font fontToUse, string phrase)
        {
            var cell = new PdfPCell(new Phrase(phrase, fontToUse));
            cell.Colspan = numberOfCol;
            cell.PaddingBottom = 10;
            cell.PaddingTop = 10;
            return cell;
        }

        public virtual void CreatePdf(string dest)
        {
            var titleFont = FontFactory.GetFont("Arial", 12, Font.BOLD);
            var sectionHeaderFont = FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.WHITE);
            var endingMessageFont = FontFactory.GetFont("Arial", 6, Font.NORMAL);
            var bodyFont = FontFactory.GetFont("Arial", 8, Font.NORMAL);

            Document document = new Document();
            var writer = PdfWriter.GetInstance(document, new FileStream(dest, FileMode.Create));
            document.Open();

            PdfPTable table = new PdfPTable(6);

            PdfPCell title = new PdfPCell(new Phrase("PERSCRIPTION DRUG PRIOR AUTHORIZATION REQUEST FORM", titleFont));
            title.Colspan = 6;
            title.HorizontalAlignment = 1;
            title.Border = 0;
            title.PaddingBottom = 10;
            table.AddCell(title);

            PdfPCell description = new PdfPCell(new Phrase("Instructions: The Workers’ Compensation insurance carrier handling the below injury is requesting a summary of medical necessity from the treating physician describing how medication is related to the injury. Please note that failure to respond to this request may result in the denial of coverage for the medication.  You may attach any additional documentation that is important for the review, e.g. chart notes or lab data, to support this request.", bodyFont));
            description.PaddingBottom = 5;
            description.Colspan = 6;
            table.AddCell(description);

            PdfPCell patientInfo = new PdfPCell(new Phrase("Patient Information", sectionHeaderFont));
            patientInfo.Colspan = 6;
            patientInfo.PaddingBottom = 10;
            patientInfo.BackgroundColor = new BaseColor(0, 0, 0);
            table.AddCell(patientInfo);

            var name = CreateCustomCell(6, bodyFont, $"Name: {Person.FirstName} {Person.LastName}");
            table.AddCell(name);

            var dateOfBirth = CreateCustomCell(2, bodyFont, $"Date of Birth: {Person.DateOfBirth}");
            table.AddCell(dateOfBirth);


            // var checked_image = Image.GetInstance(@"C:/Users/Brandon Lehr/Documents/LOWN/images/icons8-Checked Checkbox-50.png");
            // checked_image.ScaleToFit(8, 8);
            // var unChecked_image = Image.GetInstance(@"C:/Users/Brandon Lehr/Documents/LOWN/images/icons8-Unchecked Checkbox-50.png");
            // unChecked_image.ScaleToFit(8, 8);

            var gender = CreateCustomCell(2, bodyFont, $"Male or Female: {Person.Gender}");

            // var gender = new PdfPCell();
            // var genderPhrase = new Phrase();
            // genderPhrase.Add(new Chunk(checked_image, 0, 0));
            // genderPhrase.Add(new Chunk(" Male   ", bodyFont));
            // genderPhrase.Add(new Chunk(unChecked_image, 0, 0));
            // genderPhrase.Add(new Chunk(" Female", bodyFont));
            // gender.Colspan = 2;
            // gender.AddElement(genderPhrase);
            // var gender = CreateCustomCell(2, bodyFont, $"Gender: {Person.Gender}");

            table.AddCell(gender);


            var phone = CreateCustomCell(2, bodyFont, $"Phone: {Person.PhoneNumber}");
            table.AddCell(phone);

            var address = CreateCustomCell(6, bodyFont, "Address: ");
            table.AddCell(address);

            var city = CreateCustomCell(2, bodyFont, "City: ");
            table.AddCell(city);

            var state = CreateCustomCell(2, bodyFont, "State: ");
            table.AddCell(state);

            var zipcode = CreateCustomCell(2, bodyFont, "Zipcode: ");
            table.AddCell(zipcode);


            PdfPCell workersCompClaim = new PdfPCell(new Phrase("Worker’s Compensation Claim Information", sectionHeaderFont));
            workersCompClaim.Colspan = 6;
            workersCompClaim.PaddingBottom = 10;
            workersCompClaim.BackgroundColor = new BaseColor(0, 0, 0);
            table.AddCell(workersCompClaim);


            var insuranceCarrier = CreateCustomCell(6, bodyFont, "Insurance Carrier: ");
            table.AddCell(insuranceCarrier);

            var employer = CreateCustomCell(6, bodyFont, "Employer: ");
            table.AddCell(employer);

            var doi = CreateCustomCell(2, bodyFont, "DOI: ");
            table.AddCell(doi);

            var claim = CreateCustomCell(2, bodyFont, "Claim#: ");
            table.AddCell(claim);

            var icd10 = CreateCustomCell(2, bodyFont, "ICD10: ");
            table.AddCell(icd10);


            PdfPCell providerInfo = new PdfPCell(new Phrase("Provider Information", sectionHeaderFont));
            providerInfo.Colspan = 6;
            providerInfo.PaddingBottom = 10;
            providerInfo.BackgroundColor = new BaseColor(0, 0, 0);
            table.AddCell(providerInfo);

            var providerName = CreateCustomCell(4, bodyFont, "Provider's Name: ");
            table.AddCell(providerName);

            var providerId = CreateCustomCell(2, bodyFont, "Provider Id Number: ");
            table.AddCell(providerId);


            var providerPhone = CreateCustomCell(3, bodyFont, "Phone: ");
            table.AddCell(providerPhone);

            var providerFax = CreateCustomCell(3, bodyFont, "Fax: ");
            table.AddCell(providerFax);


            PdfPCell medInfo = new PdfPCell(new Phrase("Medication Information", sectionHeaderFont));
            medInfo.Colspan = 6;
            medInfo.PaddingBottom = 10;
            medInfo.BackgroundColor = new BaseColor(0, 0, 0);
            table.AddCell(medInfo);

            var medName = CreateCustomCell(5, bodyFont, "Medication Name/Strength: ");
            table.AddCell(medName);

            var refills = CreateCustomCell(1, bodyFont, "#Refills: ");
            table.AddCell(refills);


            var qty = CreateCustomCell(1, bodyFont, "Qyt: ");
            table.AddCell(qty);


            var daySupply = CreateCustomCell(1, bodyFont, "Day Supply: ");
            table.AddCell(daySupply);

            var therapy = new PdfPTable(2);

            var newTherapyText = new Phrase();
            newTherapyText.Add(new Chunk("New Therapy ", bodyFont));
            newTherapyText.Add(new Chunk("(Y or N)", endingMessageFont));
            therapy.AddCell(newTherapyText);

            var renewalText = new Phrase();
            renewalText.Add(new Chunk("Renewal ", bodyFont));
            renewalText.Add(new Chunk("(Y or N)", endingMessageFont));
            therapy.AddCell(renewalText);

            var ifRenewal = new Phrase();
            ifRenewal.Add(new Chunk("Date Initiated ", bodyFont));
            ifRenewal.Add(new Chunk("(If Renewal): ", endingMessageFont));
            therapy.AddCell(ifRenewal);
            therapy.AddCell(new PdfPCell(new Phrase("Duration of Therapy: ", bodyFont)));

            var therapyCell = new PdfPCell(therapy);
            therapyCell.Colspan = 4;
            therapyCell.Padding = 0;
            table.AddCell(therapyCell);

            PdfPCell prescribedIndication = new PdfPCell(new Phrase("Prescribed Indication: ", bodyFont));
            prescribedIndication.Colspan = 6;
            prescribedIndication.Rowspan = 2;
            prescribedIndication.PaddingBottom = 20;
            table.AddCell(prescribedIndication);

            PdfPCell divider = new PdfPCell(new Phrase("Signature", sectionHeaderFont));
            divider.Colspan = 6;
            divider.PaddingBottom = 10;
            divider.BackgroundColor = new BaseColor(0, 0, 0);
            table.AddCell(divider);

            var prescriberSignature = CreateCustomCell(4, bodyFont, "Prescriber Signature: ");
            table.AddCell(prescriberSignature);

            var prescriberDate = CreateCustomCell(2, bodyFont, "Date: ");
            table.AddCell(prescriberDate);

            PdfPCell confidentiality = new PdfPCell(new Phrase("Confidentiality Notice: The documents accompanying this transmission contain confidential health information that is legally privileged. If you are not the intended recipient, you are hereby notified that any disclosure, copying, distribution, or action taken in reliance on the contents of these documents is strictly prohibited. If you have received this information in error, please notify the sender immediately and arrange for the return or destruction of these documents.", endingMessageFont));
            confidentiality.Colspan = 6;
            table.AddCell(confidentiality);

            document.Add(table);
            document.Close();
        }
    }
}