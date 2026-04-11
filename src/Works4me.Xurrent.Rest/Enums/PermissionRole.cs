using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various permission roles.
    /// </summary>
    public enum PermissionRole
    {
        /// <summary>
        /// Indicates that the role is account owner.
        /// </summary>
        [XurrentEnum("account_owner")]
        AccountOwner,

        /// <summary>
        /// Indicates that the role is key contact.
        /// </summary>
        [XurrentEnum("key_contact")]
        KeyContact,

        /// <summary>
        /// Indicates that the role is auditor.
        /// </summary>
        [XurrentEnum("auditor")]
        Auditor,

        /// <summary>
        /// Indicates that the role is financial manager.
        /// </summary>
        [XurrentEnum("financial_manager")]
        FinancialManager,

        /// <summary>
        /// Indicates that the role is specialist.
        /// </summary>
        [XurrentEnum("specialist")]
        Specialist,

        /// <summary>
        /// Indicates that the role is service desk analyst.
        /// </summary>
        [XurrentEnum("service_desk_analyst")]
        ServiceDeskAnalyst,

        /// <summary>
        /// Indicates that the role is service desk manager.
        /// </summary>
        [XurrentEnum("service_desk_manager")]
        ServiceDeskManager,

        /// <summary>
        /// Indicates that the role is knowledge manager.
        /// </summary>
        [XurrentEnum("knowledge_manager")]
        KnowledgeManager,

        /// <summary>
        /// Indicates that the role is problem manager.
        /// </summary>
        [XurrentEnum("problem_manager")]
        ProblemManager,

        /// <summary>
        /// Indicates that the role is workflow manager.
        /// </summary>
        [XurrentEnum("workflow_manager")]
        WorkflowManager,

        /// <summary>
        /// Indicates that the role is release manager.
        /// </summary>
        [XurrentEnum("release_manager")]
        ReleaseManager,

        /// <summary>
        /// Indicates that the role is project manager.
        /// </summary>
        [XurrentEnum("project_manager")]
        ProjectManager,

        /// <summary>
        /// Indicates that the role is service level manager.
        /// </summary>
        [XurrentEnum("service_level_manager")]
        ServiceLevelManager,

        /// <summary>
        /// Indicates that the role is configuration manager.
        /// </summary>
        [XurrentEnum("configuration_manager")]
        ConfigurationManager,

        /// <summary>
        /// Indicates that the role is account designer.
        /// </summary>
        [XurrentEnum("account_designer")]
        AccountDesigner,

        /// <summary>
        /// Indicates that the role is account administrator.
        /// </summary>
        [XurrentEnum("account_administrator")]
        AccountAdministrator,

        /// <summary>
        /// Indicates that the role is directory auditor.
        /// </summary>
        [XurrentEnum("directory_auditor")]
        DirectoryAuditor,

        /// <summary>
        /// Indicates that the role is directory designer.
        /// </summary>
        [XurrentEnum("directory_designer")]
        DirectoryDesigner,

        /// <summary>
        /// Indicates that the role is directory administrator.
        /// </summary>
        [XurrentEnum("directory_administrator")]
        DirectoryAdministrator,

        /// <summary>
        /// Indicates that the role is workflow automator auditor.
        /// </summary>
        [XurrentEnum("workflow_automator_auditor")]
        WorkflowAutomatorAuditor,

        /// <summary>
        /// Indicates that the role is workflow automator specialist.
        /// </summary>
        [XurrentEnum("workflow_automator_specialist")]
        WorkflowAutomatorSpecialist
    }
}
