CREATE VIEW BenefitsView as
Select 
	Id, 
	BenefitNumber, 
	SubmittingDate, 
	SubmittingUserId, 
	BenefitTypeId, 
	BeneficiaryAddress, 
	BeneficiaryName, 
	BeneficiaryPhoneNumber, 
	BenefitStatusId, 
	AcceptingDate, 
	AcceptingUserId, 
	RejectingDate, 
	RejectingUserId, 
	RejectionReason 
from HomeLoanBenefit union select
	Id, 
	BenefitNumber, 
	SubmittingDate, 
	SubmittingUserId, 
	BenefitTypeId, 
	BeneficiaryAddress, 
	BeneficiaryName, 
	BeneficiaryPhoneNumber, 
	BenefitStatusId, 
	AcceptingDate, 
	AcceptingUserId, 
	RejectingDate, 
	RejectingUserId, 
	RejectionReason 
from SocialServiceBenefit;