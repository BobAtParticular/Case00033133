namespace NServiceBus.Features
{
    using MessageInterfaces.MessageMapper.Reflection;
    using ObjectBuilder;
    using Serializers.Json;

    /// <summary>
    /// Uses JSON as the message serialization.
    /// </summary>
    public class NewtonsoftJsonSerialization : Feature
    {
        internal NewtonsoftJsonSerialization()
        {
            EnableByDefault();
            Prerequisite(this.ShouldSerializationFeatureBeEnabled, "NewtonsoftJsonSerialization not enable since serialization definition not detected.");
        }

        /// <summary>
        /// See <see cref="Feature.Setup"/>
        /// </summary>
        protected override void Setup(FeatureConfigurationContext context)
        {
            context.Container.ConfigureComponent<MessageMapper>(DependencyLifecycle.SingleInstance);
            var c = context.Container.ConfigureComponent<NewtonsoftJsonMessageSerializer>(DependencyLifecycle.SingleInstance);

            context.Settings.ApplyTo<NewtonsoftJsonMessageSerializer>((IComponentConfig)c);
        }
    }
}