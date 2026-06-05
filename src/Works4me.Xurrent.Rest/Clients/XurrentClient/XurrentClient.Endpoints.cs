namespace Works4me.Xurrent.Rest
{
    partial class XurrentClient
    {
        /// <summary>
        /// Gets the <see cref="Rest.Account"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/account/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public AccountClient Account
        {
            get => GetInternalClient<AccountClient>();
        }

        /// <summary>
        /// Gets the <see cref="AffectedSla"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/affected_slas/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public AffectedSlaClient AffectedSlas
        {
            get => GetInternalClient<AffectedSlaClient>();
        }

        /// <summary>
        /// Gets the <see cref="AgileBoard"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/agile_boards/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public AgileBoardClient AgileBoards
        {
            get => GetInternalClient<AgileBoardClient>();
        }

        /// <summary>
        /// Gets the <see cref="AppInstance"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/app_instances/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public AppInstanceClient AppInstances
        {
            get => GetInternalClient<AppInstanceClient>();
        }

        /// <summary>
        /// Gets the <see cref="AppOfferingAutomationRule"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/app_offering_automation_rules/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public AppOfferingAutomationRuleClient AppOfferingAutomationRules
        {
            get => GetInternalClient<AppOfferingAutomationRuleClient>();
        }

        /// <summary>
        /// Gets the <see cref="AppOffering"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/app_offerings/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public AppOfferingClient AppOfferings
        {
            get => GetInternalClient<AppOfferingClient>();
        }

        /// <summary>
        /// Gets the <see cref="ArchiveItem"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/archive/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public ArchiveItemClient Archive
        {
            get => GetInternalClient<ArchiveItemClient>();
        }

        /// <summary>
        /// Gets the <see cref="Rest.AttachmentStorage"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/general/data_types/#attachments/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public AttachmentStorageClient AttachmentStorage
        {
            get => GetInternalClient<AttachmentStorageClient>();
        }

        /// <summary>
        /// Gets the <see cref="AuditLine"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/audit_entries/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public AuditLineClient AuditLines
        {
            get => GetInternalClient<AuditLineClient>();
        }

        /// <summary>
        /// Gets the <see cref="AutomationRule"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/automation_rules/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public AutomationRuleClient AutomationRules
        {
            get => GetInternalClient<AutomationRuleClient>();
        }

        /// <summary>
        /// Gets the <see cref="Broadcast"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/broadcasts/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public BroadcastClient Broadcasts
        {
            get => GetInternalClient<BroadcastClient>();
        }

        /// <summary>
        /// Gets the <see cref="Calendar"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/calendars/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public CalendarClient Calendars
        {
            get => GetInternalClient<CalendarClient>();
        }

        /// <summary>
        /// Gets the <see cref="ClosureCode"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/closure_codes/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public ClosureCodeClient ClosureCodes
        {
            get => GetInternalClient<ClosureCodeClient>();
        }

        /// <summary>
        /// Gets the <see cref="ConfigurationItem"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/configuration_items/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public ConfigurationItemClient ConfigurationItems
        {
            get => GetInternalClient<ConfigurationItemClient>();
        }

        /// <summary>
        /// Gets the <see cref="Contract"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/contracts/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public ContractClient Contracts
        {
            get => GetInternalClient<ContractClient>();
        }

        /// <summary>
        /// Gets the <see cref="Rest.CustomCollection"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/custom_collections/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public CustomCollectionClient CustomCollection
        {
            get => GetInternalClient<CustomCollectionClient>();
        }

        /// <summary>
        /// Gets the <see cref="CustomCollectionElement"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/custom_collection_elements/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public CustomCollectionElementClient CustomCollectionElements
        {
            get => GetInternalClient<CustomCollectionElementClient>();
        }

        /// <summary>
        /// Gets the <see cref="EffortClass"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/effort_classes/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public EffortClassClient EffortClasses
        {
            get => GetInternalClient<EffortClassClient>();
        }

        /// <summary>
        /// Gets the <see cref="FirstLineSupportAgreement"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/first_line_support_agreements/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public FirstLineSupportAgreementClient FirstLineSupportAgreements
        {
            get => GetInternalClient<FirstLineSupportAgreementClient>();
        }

        /// <summary>
        /// Gets the <see cref="Holiday"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/holidays/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public HolidayClient Holidays
        {
            get => GetInternalClient<HolidayClient>();
        }

        /// <summary>
        /// Gets the <see cref="Invoice"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/invoices/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public InvoiceClient Invoices
        {
            get => GetInternalClient<InvoiceClient>();
        }

        /// <summary>
        /// Gets the <see cref="KnowledgeArticleTemplate"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/knowledge_article_templates/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public KnowledgeArticleTemplateClient KnowledgeArticleTemplates
        {
            get => GetInternalClient<KnowledgeArticleTemplateClient>();
        }

        /// <summary>
        /// Gets the <see cref="KnowledgeArticle"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/knowledge_articles/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public KnowledgeArticleClient KnowledgeArticles
        {
            get => GetInternalClient<KnowledgeArticleClient>();
        }

        /// <summary>
        /// Gets the <see cref="NoteReaction"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/notes/note_reactions/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public NoteReactionClient NoteReactions
        {
            get => GetInternalClient<NoteReactionClient>();
        }

        /// <summary>
        /// Gets the <see cref="Note"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/notes/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public NoteClient Notes
        {
            get => GetInternalClient<NoteClient>();
        }

        /// <summary>
        /// Gets the <see cref="Organization"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/organizations/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public OrganizationClient Organizations
        {
            get => GetInternalClient<OrganizationClient>();
        }

        /// <summary>
        /// Gets the <see cref="OutOfOfficePeriod"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/out_of_office_periods/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public OutOfOfficePeriodClient OutOfOfficePeriods
        {
            get => GetInternalClient<OutOfOfficePeriodClient>();
        }

        /// <summary>
        /// Gets the <see cref="PdfDesign"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/pdf_designs/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public PdfDesignClient PdfDesigns
        {
            get => GetInternalClient<PdfDesignClient>();
        }

        /// <summary>
        /// Gets the <see cref="Person"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/people/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public PersonClient People
        {
            get => GetInternalClient<PersonClient>();
        }

        /// <summary>
        /// Gets the <see cref="Problem"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/problems/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public ProblemClient Problems
        {
            get => GetInternalClient<ProblemClient>();
        }

        /// <summary>
        /// Gets the <see cref="ProductBacklog"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/product_backlogs/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public ProductBacklogClient ProductBacklogs
        {
            get => GetInternalClient<ProductBacklogClient>();
        }

        /// <summary>
        /// Gets the <see cref="ProductCategory"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/product_categories/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public ProductCategoryClient ProductCategories
        {
            get => GetInternalClient<ProductCategoryClient>();
        }

        /// <summary>
        /// Gets the <see cref="Product"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/products/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public ProductClient Products
        {
            get => GetInternalClient<ProductClient>();
        }

        /// <summary>
        /// Gets the <see cref="ProjectCategory"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/project_categories/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public ProjectCategoryClient ProjectCategories
        {
            get => GetInternalClient<ProjectCategoryClient>();
        }

        /// <summary>
        /// Gets the <see cref="ProjectRiskLevel"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/project_risk_levels/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public ProjectRiskLevelClient ProjectRiskLevels
        {
            get => GetInternalClient<ProjectRiskLevelClient>();
        }

        /// <summary>
        /// Gets the <see cref="ProjectTask"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/project_tasks/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public ProjectTaskClient ProjectTasks
        {
            get => GetInternalClient<ProjectTaskClient>();
        }

        /// <summary>
        /// Gets the <see cref="ProjectTemplate"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/project_templates/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public ProjectTemplateClient ProjectTemplates
        {
            get => GetInternalClient<ProjectTemplateClient>();
        }

        /// <summary>
        /// Gets the <see cref="Project"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/projects/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public ProjectClient Projects
        {
            get => GetInternalClient<ProjectClient>();
        }

        /// <summary>
        /// Gets the <see cref="Release"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/releases/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public ReleaseClient Releases
        {
            get => GetInternalClient<ReleaseClient>();
        }

        /// <summary>
        /// Gets the <see cref="RequestTemplate"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/request_templates/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public RequestTemplateClient RequestTemplates
        {
            get => GetInternalClient<RequestTemplateClient>();
        }

        /// <summary>
        /// Gets the <see cref="Request"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/requests/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public RequestClient Requests
        {
            get => GetInternalClient<RequestClient>();
        }

        /// <summary>
        /// Gets the <see cref="ReservationOffering"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/reservation_offerings/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public ReservationOfferingClient ReservationOfferings
        {
            get => GetInternalClient<ReservationOfferingClient>();
        }

        /// <summary>
        /// Gets the <see cref="Reservation"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/reservations/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public ReservationClient Reservations
        {
            get => GetInternalClient<ReservationClient>();
        }

        /// <summary>
        /// Gets the <see cref="RfcType"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/rfc_types/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public RfcTypeClient RfcTypes
        {
            get => GetInternalClient<RfcTypeClient>();
        }

        /// <summary>
        /// Gets the <see cref="RiskSeverity"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/risk_severities/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public RiskSeverityClient RiskSeverities
        {
            get => GetInternalClient<RiskSeverityClient>();
        }

        /// <summary>
        /// Gets the <see cref="Risk"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/risks/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public RiskClient Risks
        {
            get => GetInternalClient<RiskClient>();
        }

        /// <summary>
        /// Gets the <see cref="ScrumWorkspace"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/scrum_workspaces/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public ScrumWorkspaceClient ScrumWorkspaces
        {
            get => GetInternalClient<ScrumWorkspaceClient>();
        }

        /// <summary>
        /// Gets the <see cref="ServiceCategory"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/service_categories/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public ServiceCategoryClient ServiceCategories
        {
            get => GetInternalClient<ServiceCategoryClient>();
        }

        /// <summary>
        /// Gets the <see cref="ServiceInstance"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/service_instances/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public ServiceInstanceClient ServiceInstances
        {
            get => GetInternalClient<ServiceInstanceClient>();
        }

        /// <summary>
        /// Gets the <see cref="ServiceLevelAgreement"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/service_level_agreements/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public ServiceLevelAgreementClient ServiceLevelAgreements
        {
            get => GetInternalClient<ServiceLevelAgreementClient>();
        }

        /// <summary>
        /// Gets the <see cref="ServiceOffering"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/service_offerings/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public ServiceOfferingClient ServiceOfferings
        {
            get => GetInternalClient<ServiceOfferingClient>();
        }

        /// <summary>
        /// Gets the <see cref="Service"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/services/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public ServiceClient Services
        {
            get => GetInternalClient<ServiceClient>();
        }

        /// <summary>
        /// Gets the <see cref="ShopArticleCategory"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/shop_article_categories/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public ShopArticleCategoryClient ShopArticleCategories
        {
            get => GetInternalClient<ShopArticleCategoryClient>();
        }

        /// <summary>
        /// Gets the <see cref="ShopArticle"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/shop_articles/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public ShopArticleClient ShopArticles
        {
            get => GetInternalClient<ShopArticleClient>();
        }

        /// <summary>
        /// Gets the <see cref="ShopOrderLine"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/shop_order_lines/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public ShopOrderLineClient ShopOrderLines
        {
            get => GetInternalClient<ShopOrderLineClient>();
        }

        /// <summary>
        /// Gets the <see cref="ShortUrl"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/short_urls/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public ShortUrlClient ShortUrls
        {
            get => GetInternalClient<ShortUrlClient>();
        }

        /// <summary>
        /// Gets the <see cref="Site"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/sites/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public SiteClient Sites
        {
            get => GetInternalClient<SiteClient>();
        }

        /// <summary>
        /// Gets the <see cref="SkillPool"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/skill_pools/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public SkillPoolClient SkillPools
        {
            get => GetInternalClient<SkillPoolClient>();
        }

        /// <summary>
        /// Gets the <see cref="SlaCoverageGroup"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/sla_coverage_groups/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public SlaCoverageGroupClient SlaCoverageGroups
        {
            get => GetInternalClient<SlaCoverageGroupClient>();
        }

        /// <summary>
        /// Gets the <see cref="SlaNotificationScheme"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/sla_notification_schemes/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public SlaNotificationSchemeClient SlaNotificationSchemes
        {
            get => GetInternalClient<SlaNotificationSchemeClient>();
        }

        /// <summary>
        /// Gets the <see cref="Sprint"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/sprints/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public SprintClient Sprints
        {
            get => GetInternalClient<SprintClient>();
        }

        /// <summary>
        /// Gets the <see cref="SurveyResponse"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/survey_responses/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public SurveyResponseClient SurveyResponses
        {
            get => GetInternalClient<SurveyResponseClient>();
        }

        /// <summary>
        /// Gets the <see cref="Survey"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/surveys/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public SurveyClient Surveys
        {
            get => GetInternalClient<SurveyClient>();
        }

        /// <summary>
        /// Gets the <see cref="Team"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/teams/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public TeamClient Teams
        {
            get => GetInternalClient<TeamClient>();
        }

        /// <summary>
        /// Gets the <see cref="TimeAllocation"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/time_allocations/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public TimeAllocationClient TimeAllocations
        {
            get => GetInternalClient<TimeAllocationClient>();
        }

        /// <summary>
        /// Gets the <see cref="TimeEntry"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/time_entries/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public TimeEntryClient TimeEntries
        {
            get => GetInternalClient<TimeEntryClient>();
        }

        /// <summary>
        /// Gets the <see cref="TimesheetSetting"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/timesheet_settings/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public TimesheetSettingClient TimesheetSettings
        {
            get => GetInternalClient<TimesheetSettingClient>();
        }

        /// <summary>
        /// Gets the <see cref="Timesheet"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/timesheets/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public TimesheetClient Timesheets
        {
            get => GetInternalClient<TimesheetClient>();
        }

        /// <summary>
        /// Gets the <see cref="TrashItem"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/trash/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public TrashItemClient Trash
        {
            get => GetInternalClient<TrashItemClient>();
        }

        /// <summary>
        /// Gets the <see cref="UiExtension"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/ui_extensions/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public UiExtensionClient UiExtensions
        {
            get => GetInternalClient<UiExtensionClient>();
        }

        /// <summary>
        /// Gets the <see cref="WaitingForCustomerFollowUp"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/waiting_for_customer_follow_ups/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public WaitingForCustomerFollowUpClient WaitingForCustomerFollowUps
        {
            get => GetInternalClient<WaitingForCustomerFollowUpClient>();
        }

        /// <summary>
        /// Gets the <see cref="WebhookPolicy"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/webhook_policies/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public WebhookPolicyClient WebhookPolicies
        {
            get => GetInternalClient<WebhookPolicyClient>();
        }

        /// <summary>
        /// Gets the <see cref="Webhook"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/webhooks/events/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public WebhookClient Webhooks
        {
            get => GetInternalClient<WebhookClient>();
        }

        /// <summary>
        /// Gets the <see cref="WorkflowTaskTemplate"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/task_templates/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public WorkflowTaskTemplateClient WorkflowTaskTemplates
        {
            get => GetInternalClient<WorkflowTaskTemplateClient>();
        }

        /// <summary>
        /// Gets the <see cref="WorkflowTask"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/tasks/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public WorkflowTaskClient WorkflowTasks
        {
            get => GetInternalClient<WorkflowTaskClient>();
        }

        /// <summary>
        /// Gets the <see cref="WorkflowTemplate"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/workflow_templates/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public WorkflowTemplateClient WorkflowTemplates
        {
            get => GetInternalClient<WorkflowTemplateClient>();
        }

        /// <summary>
        /// Gets the <see cref="WorkflowType"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/workflow_types/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public WorkflowTypeClient WorkflowTypes
        {
            get => GetInternalClient<WorkflowTypeClient>();
        }

        /// <summary>
        /// Gets the <see cref="Workflow"/> client.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/workflows/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public WorkflowClient Workflows
        {
            get => GetInternalClient<WorkflowClient>();
        }
    }
}
