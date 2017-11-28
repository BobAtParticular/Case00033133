namespace NServiceBus
{
    using System;
    using Features;
    using Serialization;

    /// <summary>
    /// Defines the capabilities of the JSON serializer
    /// </summary>
    public class NewtonsoftJsonSerializer : SerializationDefinition
    {
        /// <summary>
        /// <see cref="SerializationDefinition.ProvidedByFeature"/>
        /// </summary>
        protected override Type ProvidedByFeature()
        {
            return typeof(NewtonsoftJsonSerialization);
        }
    }
}