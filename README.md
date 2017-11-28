# Case00033133
Reproduction for Case 00033133

Based on the v5 JSON Serializer sample: https://docs.particular.net/samples/serializers/json/?version=core_5

Shows extracting [the embedded Json serializer from v5](https://github.com/Particular/NServiceBus/tree/support-5.2/src/NServiceBus.Core/Serializers/Json) that uses the ILmerged Newtonsoft.Json package to create a "custom" serializer that can use the `[JsonProperty]` attribute to deserialize [message properties with private setters](https://github.com/BobAtParticular/Case00033133/blob/master/Case00033133/OrderItem.cs#L12).
