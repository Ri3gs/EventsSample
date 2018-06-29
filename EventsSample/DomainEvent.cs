using System;

namespace EventsSample
{
	public abstract class DomainEvent
	{
		protected DomainEvent(Guid id, int division)
		{
			Id = id;
			Division = division;
		}

		public Guid Id { get; }

		public int Division { get; }
	}

	public class AgreedOnTermsEvent : DomainEvent
	{
		public AgreedOnTermsEvent(Guid id, int division, string companyName, string companyEmail, string iban) : base(id, division)
		{
			CompanyName = companyName;
			CompanyEmail = companyEmail;
			Iban = iban;
		}

		public string CompanyName { get; }

		public string CompanyEmail { get; }

		public string Iban { get; }
	}

	public class EmailVerificationCodeSentEvent : DomainEvent
	{
		public EmailVerificationCodeSentEvent(Guid id, int division, string verficationCode) : base(id, division)
		{
			VerficationCode = verficationCode;
		}

		public string VerficationCode { get; }
	}
}