using System;

namespace ERPNextSharp.Data
{
    public struct DocType
    {
        #region Internal
        /// <summary>
        /// DocType name
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Create a new DocType instance
        /// </summary>
        /// <param name="name">Name</param>
        public DocType(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Get string name of the DocType
        /// </summary>
        /// <returns>Name</returns>
        public override string ToString()
        {
            return Name;
        }

        #endregion

        #region Equality implementation
        public static bool operator ==(DocType a, DocType b)
        {
            return Equals(a, b);
        }

        public static bool operator !=(DocType a, DocType b)
        {
            return !(a == b);
        }

        public bool Equals(DocType other)
        {
            return String.Equals(Name, other.Name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is DocType && Equals((DocType)obj);
        }

        public override int GetHashCode()
        {
            return (Name != null ? Name.GetHashCode() : 0);
        }
        #endregion

        #region DocType definition
        #region Account DocTypes
        public static readonly DocType Asset = new DocType("Asset");
        public static readonly DocType Budget = new DocType("Budget");
        public static readonly DocType CForm = new DocType("C-Form");
        public static readonly DocType Account = new DocType("Account");
        public static readonly DocType GLEntry = new DocType("GL Entry");
        public static readonly DocType TaxRule = new DocType("Tax Rule");
        public static readonly DocType CostCenter = new DocType("Cost Center");
        public static readonly DocType FiscalYear = new DocType("Fiscal Year");
        public static readonly DocType POSProfile = new DocType("POS Profile");
        public static readonly DocType PricingRule = new DocType("Pricing Rule");
        public static readonly DocType JournalEntry   = new DocType("Journal Entry");
        public static readonly DocType PartyAccount = new DocType("Party Account");
        public static readonly DocType PaymentEntry   = new DocType("Payment Entry");
        public static readonly DocType SalesInvoice = new DocType("Sales Invoice");
        public static readonly DocType ShippingRule   = new DocType("Shipping Rule");
        public static readonly DocType AssetCategory = new DocType("Asset Category");
        public static readonly DocType AssetMovement  = new DocType("Asset Movement");
        public static readonly DocType BankGuarantee = new DocType("Bank Guarantee");
        public static readonly DocType BudgetAccount  = new DocType("Budget Account");
        public static readonly DocType POSItemGroup  = new DocType("POS Item Group");
        public static readonly DocType ModeOfPayment = new DocType("Mode of Payment");
        public static readonly DocType PaymentRequest = new DocType("Payment Request");
        public static readonly DocType PurchaseInvoice    = new DocType("Purchase Invoice");
        public static readonly DocType AccountsSettings = new DocType("Accounts Settings");
        public static readonly DocType POSCustomerGroup = new DocType("POS Customer Group");
        public static readonly DocType SalesInvoiceItem = new DocType("Sales Invoice Item");
        public static readonly DocType BankReconciliation = new DocType("Bank Reconciliation");
        public static readonly DocType FiscalYearCompany = new DocType("Fiscal Year Company");
        public static readonly DocType MonthlyDistribution = new DocType("Monthly Distribution");
        public static readonly DocType CFormInvoiceDetail = new DocType("C-Form Invoice Detail");
        public static readonly DocType ChequePrintTemplate = new DocType("Cheque Print Template");
        public static readonly DocType DepreciationSchedule   = new DocType("Depreciation Schedule");
        public static readonly DocType JournalEntryAccount   = new DocType("Journal Entry Account");
        public static readonly DocType PurchaseInvoiceItem   = new DocType("Purchase Invoice Item");
        public static readonly DocType SalesInvoiceAdvance   = new DocType("Sales Invoice Advance");
        public static readonly DocType SalesInvoicePayment   = new DocType("Sales Invoice Payment");
        public static readonly DocType ShippingRuleCountry   = new DocType("Shipping Rule Country");
        public static readonly DocType AssetCategoryAccount  = new DocType("Asset Category Account");
        public static readonly DocType PaymentReconciliation = new DocType("Payment Reconciliation");
        public static readonly DocType PeriodClosingVoucher = new DocType("Period Closing Voucher");
        public static readonly DocType ModeOfPaymentAccount = new DocType("Mode of Payment Account");
        public static readonly DocType PaymentEntryDeduction = new DocType("Payment Entry Deduction");
        public static readonly DocType PaymentEntryReference = new DocType("Payment Entry Reference");
        public static readonly DocType PaymentGatewayAccount = new DocType("Payment Gateway Account");
        public static readonly DocType SalesInvoiceTimesheet = new DocType("Sales Invoice Timesheet");
        public static readonly DocType SalesTaxesAndCharges = new DocType("Sales Taxes and Charges");
        public static readonly DocType ShippingRuleCondition = new DocType("Shipping Rule Condition");
        public static readonly DocType PurchaseInvoiceAdvance = new DocType("Purchase Invoice Advance");
        public static readonly DocType SalaryComponentAccount = new DocType("Salary Component Account");
        public static readonly DocType BankReconciliationDetail = new DocType("Bank Reconciliation Detail");
        public static readonly DocType PurchaseTaxesAndCharges  = new DocType("Purchase Taxes and Charges");
        public static readonly DocType PaymentReconciliationInvoice  = new DocType("Payment Reconciliation Invoice");
        public static readonly DocType PaymentReconciliationPayment  = new DocType("Payment Reconciliation Payment");
        public static readonly DocType MonthlyDistributionPercentage = new DocType("Monthly Distribution Percentage");
        public static readonly DocType SalesTaxesAndChargesTemplate    = new DocType("Sales Taxes and Charges Template");
        public static readonly DocType PurchaseTaxesAndChargesTemplate = new DocType("Purchase Taxes and Charges Template");
        #endregion
        #region buying DocTypes
        public static readonly DocType Supplier    = new DocType("Supplier");
        public static readonly DocType PurchaseOrder = new DocType("Purchase Order");
        public static readonly DocType BuyingSettings = new DocType("Buying Settings");
        public static readonly DocType SupplierQuotation = new DocType("Supplier Quotation");
        public static readonly DocType PurchaseOrderItem = new DocType("Purchase Order Item");
        public static readonly DocType RequestForQuotation = new DocType("Request for Quotation");
        public static readonly DocType SupplierQuotationItem = new DocType("Supplier Quotation Item");
        public static readonly DocType RequestForQuotationItem  = new DocType("Request for Quotation Item");
        public static readonly DocType PurchaseOrderItemSupplied = new DocType("Purchase Order Item Supplied");
        public static readonly DocType PurchaseReceiptItemSupplied  = new DocType("Purchase Receipt Item Supplied");
        public static readonly DocType RequestForQuotationSupplier  = new DocType("Request for Quotation Supplier");
        #endregion
        #region Core DocTypes
        public static readonly DocType Tag = new DocType("Tag");
        public static readonly DocType File    = new DocType("File");
        public static readonly DocType Page    = new DocType("Page");
        public static readonly DocType Role    = new DocType("Role");
        public static readonly DocType User    = new DocType("User");
        public static readonly DocType Report  = new DocType("Report");
        public static readonly DocType DocPerm = new DocType("DocPerm");
        public static readonly DocType Doctype = new DocType("DocType");
        public static readonly DocType Version = new DocType("Version");
        public static readonly DocType DocField    = new DocType("DocField");
        public static readonly DocType DocShare    = new DocType("DocShare");
        public static readonly DocType HasRole = new DocType("Has Role");
        public static readonly DocType Language = new DocType("Language");
        public static readonly DocType ErrorLog   = new DocType("Error Log");
        public static readonly DocType PatchLog = new DocType("Patch Log");
        public static readonly DocType ModuleDef  = new DocType("Module Def");
        public static readonly DocType UserEmail = new DocType("User Email");
        public static readonly DocType CustomRole = new DocType("Custom Role");
        public static readonly DocType Translation = new DocType("Translation");
        public static readonly DocType BlockModule = new DocType("Block Module");
        public static readonly DocType DefaultValue = new DocType("DefaultValue");
        public static readonly DocType DynamicLink    = new DocType("Dynamic Link");
        public static readonly DocType TagCategory = new DocType("Tag Category");
        public static readonly DocType Communication = new DocType("Communication");
        public static readonly DocType CustomDocPerm  = new DocType("Custom DocPerm");
        public static readonly DocType ErrorSnapshot = new DocType("Error Snapshot");
        public static readonly DocType PaymentGateway = new DocType("Payment Gateway");
        public static readonly DocType SystemSettings = new DocType("System Settings");
        public static readonly DocType DeletedDocument    = new DocType("Deleted Document");
        public static readonly DocType FeedbackRequest = new DocType("Feedback Request");
        public static readonly DocType FeedbackTrigger    = new DocType("Feedback Trigger");
        public static readonly DocType TagDocCategory    = new DocType("Tag Doc Category");
        public static readonly DocType AuthenticationLog = new DocType("Authentication Log");
        public static readonly DocType RolePermissionForPageAndReport = new DocType("Role Permission for Page and Report");
        public static readonly DocType UserPermissionForPageAndReport = new DocType("User Permission for Page and Report");
            #endregion
        #region CRM DocTypes
        public static readonly DocType Lead = new DocType("Lead");
        public static readonly DocType Opportunity = new DocType("Opportunity");
        public static readonly DocType OpportunityItem    = new DocType("Opportunity Item");
        #endregion
        #region Custom DocTypes
        public static readonly DocType CustomField = new DocType("Custom Field");
        public static readonly DocType CustomScript   = new DocType("Custom Script");
        public static readonly DocType CustomizeForm = new DocType("Customize Form");
        public static readonly DocType PropertySetter = new DocType("Property Setter");
        public static readonly DocType CustomizeFormField    = new DocType("Customize Form Field");
        #endregion
        #region Desk DocTypes
        public static readonly DocType Note    = new DocType("Note");
        public static readonly DocType ToDo    = new DocType("ToDo");
        public static readonly DocType Event   = new DocType("Event");
        public static readonly DocType BulkUpdate = new DocType("Bulk Update");
        public static readonly DocType DesktopIcon    = new DocType("Desktop Icon");
        public static readonly DocType KanbanBoard = new DocType("Kanban Board");
        public static readonly DocType NoteSeenBy = new DocType("Note Seen By");
        public static readonly DocType KanbanBoardColumn = new DocType("Kanban Board Column");
        #endregion
        #region Email DocTypes
        public static readonly DocType Contact = new DocType("Contact");
        public static readonly DocType EmailRule  = new DocType("Email Rule");
        public static readonly DocType Newsletter  = new DocType("Newsletter");
        public static readonly DocType EmailAlert = new DocType("Email Alert");
        public static readonly DocType EmailGroup = new DocType("Email Group");
        public static readonly DocType EmailQueue = new DocType("Email Queue");
        public static readonly DocType EmailDomain    = new DocType("Email Domain");
        public static readonly DocType EmailAccount = new DocType("Email Account");
        public static readonly DocType StandardReply  = new DocType("Standard Reply");
        public static readonly DocType UnhandledEmail = new DocType("Unhandled Email");
        public static readonly DocType EmailFlagQueue = new DocType("Email Flag Queue");
        public static readonly DocType AutoEmailReport = new DocType("Auto Email Report");
        public static readonly DocType EmailUnsubscribe   = new DocType("Email Unsubscribe");
        public static readonly DocType EmailGroupMember  = new DocType("Email Group Member");
        public static readonly DocType EmailAlertRecipient   = new DocType("Email Alert Recipient");
        public static readonly DocType EmailQueueRecipient   = new DocType("Email Queue Recipient");
        public static readonly DocType NewsletterEmailGroup  = new DocType("Newsletter Email Group");
        #endregion
        #region Geo DocTypes
        public static readonly DocType Address = new DocType("Address");
        public static readonly DocType Country = new DocType("Country");
        public static readonly DocType Currency    = new DocType("Currency");
        public static readonly DocType AddressTemplate = new DocType("Address Template");
            #endregion
        #region HR DocTypes
        public static readonly DocType Branch = new DocType("Branch");
        public static readonly DocType Holiday = new DocType("Holiday");
        public static readonly DocType Vehicle = new DocType("Vehicle");
        public static readonly DocType Employee = new DocType("Employee");
        public static readonly DocType Interest = new DocType("Interest");
        public static readonly DocType Appraisal = new DocType("Appraisal");
        public static readonly DocType LoanType   = new DocType("Loan Type");
        public static readonly DocType Attendance  = new DocType("Attendance");
        public static readonly DocType Department  = new DocType("Department");
        public static readonly DocType LeaveType = new DocType("Leave Type");
        public static readonly DocType OfferTerm  = new DocType("Offer Term");
        public static readonly DocType Designation = new DocType("Designation");
        public static readonly DocType HRSettings = new DocType("HR Settings");
        public static readonly DocType JobOpening = new DocType("Job Opening");
        public static readonly DocType SalarySlip = new DocType("Salary Slip");
        public static readonly DocType VehicleLog = new DocType("Vehicle Log");
        public static readonly DocType HolidayList = new DocType("Holiday List");
        public static readonly DocType OfferLetter    = new DocType("Offer Letter");
        public static readonly DocType EmployeeLoan = new DocType("Employee Loan");
        public static readonly DocType ExpenseClaim   = new DocType("Expense Claim");
        public static readonly DocType JobApplicant = new DocType("Job Applicant");
        public static readonly DocType SalaryDetail   = new DocType("Salary Detail");
        public static readonly DocType AppraisalGoal = new DocType("Appraisal Goal");
        public static readonly DocType TrainingEvent  = new DocType("Training Event");
        public static readonly DocType EmploymentType = new DocType("Employment Type");
        public static readonly DocType ProcessPayroll = new DocType("Process Payroll");
        public static readonly DocType TrainingResult = new DocType("Training Result");
        public static readonly DocType VehicleService = new DocType("Vehicle Service");
        public static readonly DocType LeaveAllocation = new DocType("Leave Allocation");
        public static readonly DocType LeaveBlockList = new DocType("Leave Block List");
        public static readonly DocType SalaryComponent    = new DocType("Salary Component");
        public static readonly DocType SalaryStructure = new DocType("Salary Structure");
        public static readonly DocType LeaveApplication   = new DocType("Leave Application");
        public static readonly DocType OfferLetterTerm   = new DocType("Offer Letter Term");
        public static readonly DocType TrainingFeedback = new DocType("Training Feedback");
        public static readonly DocType UploadAttendance   = new DocType("Upload Attendance");
        public static readonly DocType AppraisalTemplate = new DocType("Appraisal Template");
        public static readonly DocType DailyWorkSummary = new DocType("Daily Work Summary");
        public static readonly DocType EmployeeEducation  = new DocType("Employee Education");
        public static readonly DocType ExpenseClaimType  = new DocType("Expense Claim Type");
        public static readonly DocType RepaymentSchedule = new DocType("Repayment Schedule");
        public static readonly DocType LeaveControlPanel = new DocType("Leave Control Panel");
        public static readonly DocType ExpenseClaimDetail = new DocType("Expense Claim Detail");
        public static readonly DocType ExpenseClaimAccount = new DocType("Expense Claim Account");
        public static readonly DocType LeaveBlockListDate   = new DocType("Leave Block List Date");
        public static readonly DocType SalarySlipTimesheet   = new DocType("Salary Slip Timesheet");
        public static readonly DocType LeaveBlockListAllow = new DocType("Leave Block List Allow");
        public static readonly DocType AppraisalTemplateGoal = new DocType("Appraisal Template Goal");
        public static readonly DocType EmployeeLeaveApprover = new DocType("Employee Leave Approver");
        public static readonly DocType TrainingEventEmployee = new DocType("Training Event Employee");
        public static readonly DocType EmployeeAttendanceTool = new DocType("Employee Attendance Tool");
        public static readonly DocType TrainingResultEmployee = new DocType("Training Result Employee");
        public static readonly DocType EmployeeLoanApplication = new DocType("Employee Loan Application");
        public static readonly DocType SalaryStructureEmployee = new DocType("Salary Structure Employee");
        public static readonly DocType DailyWorkSummarySettings = new DocType("Daily Work Summary Settings");
        public static readonly DocType EmployeeExternalWorkHistory = new DocType("Employee External Work History");
        public static readonly DocType EmployeeInternalWorkHistory  = new DocType("Employee Internal Work History");
        public static readonly DocType DailyWorkSummarySettingsCompany = new DocType("Daily Work Summary Settings Company");
        #endregion
        #region Hub Node DocTypes
        public static readonly DocType HubSettings = new DocType("Hub Settings");
        #endregion
        #region Integrations DocTypes
        public static readonly DocType OAuthClient = new DocType("OAuth Client");
        public static readonly DocType LDAPSettings   = new DocType("LDAP Settings");
        public static readonly DocType PayPalSettings = new DocType("PayPal Settings");
        public static readonly DocType StripeSettings = new DocType("Stripe Settings");
        public static readonly DocType DropboxSettings = new DocType("Dropbox Settings");
        public static readonly DocType RazorpaySettings   = new DocType("Razorpay Settings");
        public static readonly DocType SocialLoginKeys   = new DocType("Social Login Keys");
        public static readonly DocType OAuthBearerToken  = new DocType("OAuth Bearer Token");
        public static readonly DocType IntegrationRequest = new DocType("Integration Request");
        public static readonly DocType OAuthProviderSettings = new DocType("OAuth Provider Settings");
        public static readonly DocType OAuthAuthorizationCode = new DocType("OAuth Authorization Code");
        #endregion
        #region Maintenance DocTypes
        public static readonly DocType MaintenanceVisit   = new DocType("Maintenance Visit");
        public static readonly DocType MaintenanceSchedule = new DocType("Maintenance Schedule");
        public static readonly DocType MaintenanceScheduleItem = new DocType("Maintenance Schedule Item");
        public static readonly DocType MaintenanceVisitPurpose = new DocType("Maintenance Visit Purpose");
        public static readonly DocType MaintenanceScheduleDetail = new DocType("Maintenance Schedule Detail");
        #endregion
        #region Manufacturing DocTypes
        public static readonly DocType BOM = new DocType("BOM");
        public static readonly DocType BOMItem    = new DocType("BOM Item");
        public static readonly DocType Operation   = new DocType("Operation");
        public static readonly DocType Workstation = new DocType("Workstation");
        public static readonly DocType BOMOperation = new DocType("BOM Operation");
        public static readonly DocType BOMScrapItem = new DocType("BOM Scrap Item");
        public static readonly DocType BOMReplaceTool = new DocType("BOM Replace Tool");
        public static readonly DocType BOMWebsiteItem = new DocType("BOM Website Item");
        public static readonly DocType ProductionOrder    = new DocType("Production Order");
        public static readonly DocType BOMExplosionItem  = new DocType("BOM Explosion Item");
        public static readonly DocType ProductionPlanItem    = new DocType("Production Plan Item");
        public static readonly DocType BOMWebsiteOperation   = new DocType("BOM Website Operation");
        public static readonly DocType ProductionOrderItem   = new DocType("Production Order Item");
        public static readonly DocType ManufacturingSettings = new DocType("Manufacturing Settings");
        public static readonly DocType ProductionPlanningTool = new DocType("Production Planning Tool");
        public static readonly DocType WorkstationWorkingHour = new DocType("Workstation Working Hour");
        public static readonly DocType ProductionOrderOperation = new DocType("Production Order Operation");
        public static readonly DocType ProductionPlanSalesOrder = new DocType("Production Plan Sales Order");
        public static readonly DocType ProductionPlanMaterialRequest = new DocType("Production Plan Material Request");
            #endregion
        #region Portal DocTypes
        public static readonly DocType Homepage = new DocType("Homepage");
        public static readonly DocType ProductsSettings   = new DocType("Products Settings");
        public static readonly DocType HomepageFeaturedProduct = new DocType("Homepage Featured Product");
        #endregion
        #region Printing DocTypes
        public static readonly DocType LetterHead = new DocType("Letter Head");
        public static readonly DocType PrintFormat    = new DocType("Print Format");
        public static readonly DocType PrintSettings = new DocType("Print Settings");
        #endregion
        #region Projects DocTypes
        public static readonly DocType Task = new DocType("Task");
        public static readonly DocType Project = new DocType("Project");
        public static readonly DocType Timesheet = new DocType("Timesheet");
        public static readonly DocType ProjectTask    = new DocType("Project Task");
        public static readonly DocType ProjectUser = new DocType("Project User");
        public static readonly DocType ActivityCost   = new DocType("Activity Cost");
        public static readonly DocType ActivityType = new DocType("Activity Type"); 
        public static readonly DocType DependentTask  = new DocType("Dependent Task"); 
        public static readonly DocType TaskDependsOn = new DocType("Task Depends On");
        public static readonly DocType TimesheetDetail = new DocType("Timesheet Detail");
        #endregion
        #region Schools DocTypes
        public static readonly DocType Fees = new DocType("Fees");
        public static readonly DocType Room = new DocType("Room");
        public static readonly DocType Course = new DocType("Course");
        public static readonly DocType Program = new DocType("Program");
        public static readonly DocType Student = new DocType("Student");
        public static readonly DocType Guardian = new DocType("Guardian");
        public static readonly DocType Instructor = new DocType("Instructor");
        public static readonly DocType ProgramFee = new DocType("Program Fee");
        public static readonly DocType StudentLog = new DocType("Student Log");
        public static readonly DocType FeeCategory    = new DocType("Fee Category");
        public static readonly DocType SchoolHouse = new DocType("School House");
        public static readonly DocType AcademicTerm   = new DocType("Academic Term");
        public static readonly DocType AcademicYear = new DocType("Academic Year");
        public static readonly DocType FeeComponent   = new DocType("Fee Component");
        public static readonly DocType FeeStructure = new DocType("Fee Structure");
        public static readonly DocType GradingScale   = new DocType("Grading Scale");
        public static readonly DocType StudentGroup = new DocType("Student Group");
        public static readonly DocType GradeInterval  = new DocType("Grade Interval");
        public static readonly DocType ProgramCourse = new DocType("Program Course");
        public static readonly DocType AssessmentCode = new DocType("Assessment Code");
        public static readonly DocType AssessmentPlan = new DocType("Assessment Plan");
        public static readonly DocType CourseSchedule = new DocType("Course Schedule");
        public static readonly DocType SchoolSettings = new DocType("School Settings");
        public static readonly DocType StudentSibling = new DocType("Student Sibling");
        public static readonly DocType AssessmentGroup = new DocType("Assessment Group");
        public static readonly DocType GuardianStudent    = new DocType("Guardian Student");
        public static readonly DocType StudentCategory = new DocType("Student Category");
        public static readonly DocType StudentGuardian    = new DocType("Student Guardian");
        public static readonly DocType StudentLanguage = new DocType("Student Language");
        public static readonly DocType StudentSiblings    = new DocType("Student Siblings");
        public static readonly DocType AssessmentResult = new DocType("Assessment Result");
        public static readonly DocType GradingStructure   = new DocType("Grading Structure");
        public static readonly DocType GuardianInterest = new DocType("Guardian Interest");
        public static readonly DocType StudentAdmission   = new DocType("Student Admission");
        public static readonly DocType StudentApplicant = new DocType("Student Applicant");
        public static readonly DocType ProgramEnrollment  = new DocType("Program Enrollment");
        public static readonly DocType StudentAttendance = new DocType("Student Attendance");
        public static readonly DocType StudentBatchName = new DocType("Student Batch Name");
        public static readonly DocType AssessmentCriteria = new DocType("Assessment Criteria");
        public static readonly DocType StudentGroupStudent = new DocType("Student Group Student");
        public static readonly DocType AssessmentResultTool = new DocType("Assessment Result Tool");
        public static readonly DocType CourseSchedulingTool = new DocType("Course Scheduling Tool");
        public static readonly DocType GradingScaleInterval = new DocType("Grading Scale Interval");
        public static readonly DocType ProgramEnrollmentFee = new DocType("Program Enrollment Fee");
        public static readonly DocType ProgramEnrollmentTool = new DocType("Program Enrollment Tool");
        public static readonly DocType StudentAttendanceTool = new DocType("Student Attendance Tool");
        public static readonly DocType AssessmentPlanCriteria = new DocType("Assessment Plan Criteria");
        public static readonly DocType AssessmentResultDetail = new DocType("Assessment Result Detail");
        public static readonly DocType StudentGroupInstructor = new DocType("Student Group Instructor");
        public static readonly DocType AssessmentCriteriaGroup = new DocType("Assessment Criteria Group");
        public static readonly DocType ProgramEnrollmentCourse = new DocType("Program Enrollment Course");
        public static readonly DocType StudentLeaveApplication = new DocType("Student Leave Application");
        public static readonly DocType CourseAssessmentCriteria = new DocType("Course Assessment Criteria");
        public static readonly DocType StudentGroupCreationTool = new DocType("Student Group Creation Tool");
        public static readonly DocType ProgramEnrollmentToolStudent = new DocType("Program Enrollment Tool Student");
        public static readonly DocType StudentGroupCreationToolCourse = new DocType("Student Group Creation Tool Course");
        #endregion
        #region Selling DocTypes
        public static readonly DocType Campaign = new DocType("Campaign");
        public static readonly DocType Customer = new DocType("Customer");
        public static readonly DocType Quotation = new DocType("Quotation");
        public static readonly DocType SMSCenter = new DocType("SMS Center");
        public static readonly DocType SalesTeam  = new DocType("Sales Team");
        public static readonly DocType LeadSource = new DocType("Lead Source");
        public static readonly DocType SalesOrder = new DocType("Sales Order");
        public static readonly DocType IndustryType = new DocType("Industry Type");
        public static readonly DocType ProductBundle  = new DocType("Product Bundle");
        public static readonly DocType QuotationItem = new DocType("Quotation Item");
        public static readonly DocType SalesOrderItem = new DocType("Sales Order Item");
        public static readonly DocType SellingSettings    = new DocType("Selling Settings");
        public static readonly DocType InstallationNote = new DocType("Installation Note");
        public static readonly DocType ProductBundleItem = new DocType("Product Bundle Item");
        public static readonly DocType InstallationNoteItem = new DocType("Installation Note Item");
        #endregion
        #region Setup DocTypes
        public static readonly DocType UOM = new DocType("UOM");
        public static readonly DocType Brand = new DocType("Brand");
        public static readonly DocType Company = new DocType("Company");
        public static readonly DocType Territory = new DocType("Territory");
        public static readonly DocType ItemGroup  = new DocType("Item Group");
        public static readonly DocType PartyType = new DocType("Party Type");
        public static readonly DocType EmailDigest    = new DocType("Email Digest");
        public static readonly DocType SMSSettings = new DocType("SMS Settings");
        public static readonly DocType SalesPerson    = new DocType("Sales Person");
        public static readonly DocType NamingSeries = new DocType("Naming Series");
        public static readonly DocType PrintHeading   = new DocType("Print Heading");
        public static readonly DocType SMSParameter = new DocType("SMS Parameter");
        public static readonly DocType SalesPartner   = new DocType("Sales Partner");
        public static readonly DocType SupplierType = new DocType("Supplier Type");
        public static readonly DocType TargetDetail   = new DocType("Target Detail");
        public static readonly DocType CustomerGroup = new DocType("Customer Group");
        public static readonly DocType GlobalDefaults = new DocType("Global Defaults");
        public static readonly DocType CurrencyExchange = new DocType("Currency Exchange");
        public static readonly DocType AuthorizationRule  = new DocType("Authorization Rule");
        public static readonly DocType WebsiteItemGroup = new DocType("Website Item Group");
        public static readonly DocType NotificationControl = new DocType("Notification Control");
        public static readonly DocType TermsAndConditions = new DocType("Terms and Conditions");
        public static readonly DocType AuthorizationControl   = new DocType("Authorization Control");
        public static readonly DocType QuotationLostReason = new DocType("Quotation Lost Reason");
        #endregion
        #region Shopping Cart DocTypes
        public static readonly DocType ShoppingCartSettings = new DocType("Shopping Cart Settings");
        #endregion
        #region Stock DocTypes
        public static readonly DocType Bin = new DocType("Bin");
        public static readonly DocType Item = new DocType("Item");
        public static readonly DocType Batch = new DocType("Batch");
        public static readonly DocType ItemTax    = new DocType("Item Tax");
        public static readonly DocType SerialNo = new DocType("Serial No");
        public static readonly DocType Warehouse = new DocType("Warehouse");
        public static readonly DocType ItemPrice  = new DocType("Item Price");
        public static readonly DocType PriceList = new DocType("Price List");
        public static readonly DocType PackedItem = new DocType("Packed Item");
        public static readonly DocType StockEntry = new DocType("Stock Entry");
        public static readonly DocType ItemReorder    = new DocType("Item Reorder");
        public static readonly DocType ItemVariant = new DocType("Item Variant");
        public static readonly DocType Manufacturer = new DocType("Manufacturer");
        public static readonly DocType PackageCode    = new DocType("Package Code");
        public static readonly DocType PackingSlip = new DocType("Packing Slip");
        public static readonly DocType DeliveryNote   = new DocType("Delivery Note");
        public static readonly DocType ItemSupplier = new DocType("Item Supplier");
        public static readonly DocType ItemAttribute  = new DocType("Item Attribute");
        public static readonly DocType StockSettings = new DocType("Stock Settings");
        public static readonly DocType LandedCostItem = new DocType("Landed Cost Item");
        public static readonly DocType MaterialRequest    = new DocType("Material Request");
        public static readonly DocType PurchaseReceipt = new DocType("Purchase Receipt");
        public static readonly DocType PackingSlipItem = new DocType("Packing Slip Item");
        public static readonly DocType DeliveryNoteItem = new DocType("Delivery Note Item");
        public static readonly DocType PriceListCountry = new DocType("Price List Country");
        public static readonly DocType QualityInspection  = new DocType("Quality Inspection");
        public static readonly DocType StockEntryDetail = new DocType("Stock Entry Detail");
        public static readonly DocType StockLedgerEntry = new DocType("Stock Ledger Entry");
        public static readonly DocType LandedCostVoucher = new DocType("Landed Cost Voucher");
        public static readonly DocType ItemAttributeValue = new DocType("Item Attribute Value");
        public static readonly DocType ItemCustomerDetail = new DocType("Item Customer Detail");
        public static readonly DocType StockReconciliation = new DocType("Stock Reconciliation");
        public static readonly DocType CustomsTariffNumber = new DocType("Customs Tariff Number");
        public static readonly DocType MaterialRequestItem = new DocType("Material Request Item");
        public static readonly DocType PurchaseReceiptItem = new DocType("Purchase Receipt Item");
        public static readonly DocType UOMConversionDetail = new DocType("UOM Conversion Detail");
        public static readonly DocType ItemVariantAttribute = new DocType("Item Variant Attribute");
        public static readonly DocType StockReconciliationItem = new DocType("Stock Reconciliation Item");
        public static readonly DocType ItemWebsiteSpecification = new DocType("Item Website Specification");
        public static readonly DocType QualityInspectionReading = new DocType("Quality Inspection Reading");
        public static readonly DocType LandedCostPurchaseReceipt    = new DocType("Landed Cost Purchase Receipt");
        public static readonly DocType LandedCostTaxesAndCharges = new DocType("Landed Cost Taxes and Charges");
        public static readonly DocType ItemQualityInspectionParameter = new DocType("Item Quality Inspection Parameter");
        #endregion
        #region Support DocTypes
        public static readonly DocType Issue = new DocType("Issue");
        public static readonly DocType WarrantyClaim  = new DocType("Warranty Claim");
        public static readonly DocType SupportSettings = new DocType("Support Settings");
        #endregion
        #region Utilities DocTypes
        public static readonly DocType SMSLog = new DocType("SMS Log");
        public static readonly DocType RenameTool = new DocType("Rename Tool");
        #endregion
        #region Website DocTypes
        public static readonly DocType Blogger = new DocType("Blogger");
        public static readonly DocType WebForm    = new DocType("Web Form");
        public static readonly DocType WebPage = new DocType("Web Page");
        public static readonly DocType BlogPost   = new DocType("Blog Post");
        public static readonly DocType FooterItem = new DocType("Footer Item");
        public static readonly DocType HelpArticle    = new DocType("Help Article");
        public static readonly DocType TopBarItem = new DocType("Top Bar Item");
        public static readonly DocType BlogCategory = new DocType("Blog Category");
        public static readonly DocType BlogSettings   = new DocType("Blog Settings");
        public static readonly DocType HelpCategory = new DocType("Help Category");
        public static readonly DocType WebsiteTheme   = new DocType("Website Theme");
        public static readonly DocType WebFormField = new DocType("Web Form Field");
        public static readonly DocType WebsiteScript = new DocType("Website Script");
        public static readonly DocType CompanyHistory = new DocType("Company History");
        public static readonly DocType PortalSettings = new DocType("Portal Settings");
        public static readonly DocType WebsiteSidebar = new DocType("Website Sidebar");
        public static readonly DocType PortalMenuItem = new DocType("Portal Menu Item");
        public static readonly DocType WebsiteSettings = new DocType("Website Settings");
        public static readonly DocType AboutUsSettings = new DocType("About Us Settings");
        public static readonly DocType WebsiteSlideshow   = new DocType("Website Slideshow");
        public static readonly DocType ContactUsSettings = new DocType("Contact Us Settings");
        public static readonly DocType AboutUsTeamMember = new DocType("About Us Team Member");
        public static readonly DocType WebsiteSidebarItem = new DocType("Website Sidebar Item");
        public static readonly DocType WebsiteSlideshowItem = new DocType("Website Slideshow Item");
        #endregion
        #region Workflow DocTypes
        public static readonly DocType Workflow = new DocType("Workflow");
        public static readonly DocType WorkflowState  = new DocType("Workflow State");
        public static readonly DocType WorkflowAction = new DocType("Workflow Action");
        public static readonly DocType WorkflowTransition = new DocType("Workflow Transition");
        public static readonly DocType WorkflowDocumentState = new DocType("Workflow Document State");
        #endregion

        #endregion
    }
}
