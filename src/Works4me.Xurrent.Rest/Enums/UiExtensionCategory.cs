using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various UI extension categories.
    /// </summary>
    public enum UiExtensionCategory
    {
        /// <summary>
        /// Indicates that the UI extension applies to request template records.
        /// </summary>
        [XurrentEnum("request_template")]
        RequestTemplate,

        /// <summary>
        /// Indicates that the UI extension applies to knowledge article template records.
        /// </summary>
        [XurrentEnum("knowledge_article_template")]
        KnowledgeArticleTemplate,

        /// <summary>
        /// Indicates that the UI extension applies to problem records.
        /// </summary>
        [XurrentEnum("problem")]
        Problem,

        /// <summary>
        /// Indicates that the UI extension applies to release records.
        /// </summary>
        [XurrentEnum("release")]
        Release,

        /// <summary>
        /// Indicates that the UI extension applies to workflow template records.
        /// </summary>
        [XurrentEnum("workflow_template")]
        WorkflowTemplate,

        /// <summary>
        /// Indicates that the UI extension applies to task template records.
        /// </summary>
        [XurrentEnum("task_template")]
        TaskTemplate,

        /// <summary>
        /// Indicates that the UI extension applies to project records.
        /// </summary>
        [XurrentEnum("project")]
        Project,

        /// <summary>
        /// Indicates that the UI extension applies to project task template records.
        /// </summary>
        [XurrentEnum("project_task_template")]
        ProjectTaskTemplate,

        /// <summary>
        /// Indicates that the UI extension applies to service records.
        /// </summary>
        [XurrentEnum("service")]
        Service,

        /// <summary>
        /// Indicates that the UI extension applies to service instance records.
        /// </summary>
        [XurrentEnum("service_instance")]
        ServiceInstance,

        /// <summary>
        /// Indicates that the UI extension applies to product records.
        /// </summary>
        [XurrentEnum("product")]
        Product,

        /// <summary>
        /// Indicates that the UI extension applies to product category records.
        /// </summary>
        [XurrentEnum("product_category")]
        ProductCategory,

        /// <summary>
        /// Indicates that the UI extension applies to contract records.
        /// </summary>
        [XurrentEnum("contract")]
        Contract,

        /// <summary>
        /// Indicates that the UI extension applies to organization records.
        /// </summary>
        [XurrentEnum("organization")]
        Organization,

        /// <summary>
        /// Indicates that the UI extension applies to team records.
        /// </summary>
        [XurrentEnum("team")]
        Team,

        /// <summary>
        /// Indicates that the UI extension applies to person records.
        /// </summary>
        [XurrentEnum("person")]
        Person,

        /// <summary>
        /// Indicates that the UI extension applies to site records.
        /// </summary>
        [XurrentEnum("site")]
        Site,

        /// <summary>
        /// Indicates that the UI extension applies to risk records.
        /// </summary>
        [XurrentEnum("risk")]
        Risk,

        /// <summary>
        /// Indicates that the UI extension applies to custom collection records.
        /// </summary>
        [XurrentEnum("custom_collection")]
        CustomCollection,

        /// <summary>
        /// Indicates that the UI extension applies to SCIM user records.
        /// </summary>
        [XurrentEnum("scim_user")]
        ScimUser,

        /// <summary>
        /// Indicates that the UI extension applies to app offering records.
        /// </summary>
        [XurrentEnum("app_offering")]
        AppOffering,

        /// <summary>
        /// Indicates that the UI extension applies to shop article records.
        /// </summary>
        [XurrentEnum("shop_article")]
        ShopArticle
    }
}
