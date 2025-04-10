<a name='assembly'></a>
# Black.Beard.Expressions

## Contents

- [AccessorExtensions](#T-Bb-Accessors-AccessorExtensions 'Bb.Accessors.AccessorExtensions')
  - [GetAccessors(type,strategy,filter,memberFilter)](#M-Bb-Accessors-AccessorExtensions-GetAccessors-System-Type,Bb-Accessors-MemberStrategy,System-Func{System-Type,System-Boolean},System-Func{System-Reflection-MemberInfo,System-Boolean}- 'Bb.Accessors.AccessorExtensions.GetAccessors(System.Type,Bb.Accessors.MemberStrategy,System.Func{System.Type,System.Boolean},System.Func{System.Reflection.MemberInfo,System.Boolean})')
  - [GetAccessors(type,filter,memberFilter)](#M-Bb-Accessors-AccessorExtensions-GetAccessors-System-Type,System-Func{System-Type,System-Boolean},System-Func{System-Reflection-MemberInfo,System-Boolean}- 'Bb.Accessors.AccessorExtensions.GetAccessors(System.Type,System.Func{System.Type,System.Boolean},System.Func{System.Reflection.MemberInfo,System.Boolean})')
  - [ToList(attributes)](#M-Bb-Accessors-AccessorExtensions-ToList-System-ComponentModel-AttributeCollection- 'Bb.Accessors.AccessorExtensions.ToList(System.ComponentModel.AttributeCollection)')
- [AccessorItem](#T-Bb-Accessors-AccessorItem 'Bb.Accessors.AccessorItem')
  - [#ctor(memberTypeEnum)](#M-Bb-Accessors-AccessorItem-#ctor-System-Type,Bb-Accessors-MemberTypeEnum,Bb-Accessors-MemberStrategy- 'Bb.Accessors.AccessorItem.#ctor(System.Type,Bb.Accessors.MemberTypeEnum,Bb.Accessors.MemberStrategy)')
  - [_lock](#F-Bb-Accessors-AccessorItem-_lock 'Bb.Accessors.AccessorItem._lock')
  - [_strategyPropertiesAccessors](#F-Bb-Accessors-AccessorItem-_strategyPropertiesAccessors 'Bb.Accessors.AccessorItem._strategyPropertiesAccessors')
  - [CanRead](#P-Bb-Accessors-AccessorItem-CanRead 'Bb.Accessors.AccessorItem.CanRead')
  - [CanWrite](#P-Bb-Accessors-AccessorItem-CanWrite 'Bb.Accessors.AccessorItem.CanWrite')
  - [Category](#P-Bb-Accessors-AccessorItem-Category 'Bb.Accessors.AccessorItem.Category')
  - [ComponentType](#P-Bb-Accessors-AccessorItem-ComponentType 'Bb.Accessors.AccessorItem.ComponentType')
  - [DeclaringType](#P-Bb-Accessors-AccessorItem-DeclaringType 'Bb.Accessors.AccessorItem.DeclaringType')
  - [DefaultValue](#P-Bb-Accessors-AccessorItem-DefaultValue 'Bb.Accessors.AccessorItem.DefaultValue')
  - [DisplayDescription](#P-Bb-Accessors-AccessorItem-DisplayDescription 'Bb.Accessors.AccessorItem.DisplayDescription')
  - [DisplayName](#P-Bb-Accessors-AccessorItem-DisplayName 'Bb.Accessors.AccessorItem.DisplayName')
  - [GetValue](#P-Bb-Accessors-AccessorItem-GetValue 'Bb.Accessors.AccessorItem.GetValue')
  - [IsClonable](#P-Bb-Accessors-AccessorItem-IsClonable 'Bb.Accessors.AccessorItem.IsClonable')
  - [IsStatic](#P-Bb-Accessors-AccessorItem-IsStatic 'Bb.Accessors.AccessorItem.IsStatic')
  - [Member](#P-Bb-Accessors-AccessorItem-Member 'Bb.Accessors.AccessorItem.Member')
  - [Name](#P-Bb-Accessors-AccessorItem-Name 'Bb.Accessors.AccessorItem.Name')
  - [Required](#P-Bb-Accessors-AccessorItem-Required 'Bb.Accessors.AccessorItem.Required')
  - [SetValue](#P-Bb-Accessors-AccessorItem-SetValue 'Bb.Accessors.AccessorItem.SetValue')
  - [Strategy](#P-Bb-Accessors-AccessorItem-Strategy 'Bb.Accessors.AccessorItem.Strategy')
  - [Tag](#P-Bb-Accessors-AccessorItem-Tag 'Bb.Accessors.AccessorItem.Tag')
  - [Type](#P-Bb-Accessors-AccessorItem-Type 'Bb.Accessors.AccessorItem.Type')
  - [TypeEnum](#P-Bb-Accessors-AccessorItem-TypeEnum 'Bb.Accessors.AccessorItem.TypeEnum')
  - [ContainsAttribute\`\`1()](#M-Bb-Accessors-AccessorItem-ContainsAttribute``1 'Bb.Accessors.AccessorItem.ContainsAttribute``1')
  - [ContainsAttribute\`\`1(instance)](#M-Bb-Accessors-AccessorItem-ContainsAttribute``1-System-Object- 'Bb.Accessors.AccessorItem.ContainsAttribute``1(System.Object)')
  - [ConvertBeforeSettingValue(instance,value)](#M-Bb-Accessors-AccessorItem-ConvertBeforeSettingValue-System-Object,System-Object- 'Bb.Accessors.AccessorItem.ConvertBeforeSettingValue(System.Object,System.Object)')
  - [GetAttributes()](#M-Bb-Accessors-AccessorItem-GetAttributes 'Bb.Accessors.AccessorItem.GetAttributes')
  - [GetAttributes(instance)](#M-Bb-Accessors-AccessorItem-GetAttributes-System-Object- 'Bb.Accessors.AccessorItem.GetAttributes(System.Object)')
  - [GetAttributes\`\`1()](#M-Bb-Accessors-AccessorItem-GetAttributes``1 'Bb.Accessors.AccessorItem.GetAttributes``1')
  - [GetAttributes\`\`1(instance)](#M-Bb-Accessors-AccessorItem-GetAttributes``1-System-Object- 'Bb.Accessors.AccessorItem.GetAttributes``1(System.Object)')
  - [GetTypedValue\`\`1(instance)](#M-Bb-Accessors-AccessorItem-GetTypedValue``1-System-Object- 'Bb.Accessors.AccessorItem.GetTypedValue``1(System.Object)')
  - [GetValidatedValue(instance,attributes)](#M-Bb-Accessors-AccessorItem-GetValidatedValue-System-Object,System-Collections-Generic-IEnumerable{System-ComponentModel-DataAnnotations-ValidationAttribute}- 'Bb.Accessors.AccessorItem.GetValidatedValue(System.Object,System.Collections.Generic.IEnumerable{System.ComponentModel.DataAnnotations.ValidationAttribute})')
  - [IfAttribute\`\`1()](#M-Bb-Accessors-AccessorItem-IfAttribute``1-``0@- 'Bb.Accessors.AccessorItem.IfAttribute``1(``0@)')
  - [IfAttribute\`\`1(instance,attribute)](#M-Bb-Accessors-AccessorItem-IfAttribute``1-System-Object,``0@- 'Bb.Accessors.AccessorItem.IfAttribute``1(System.Object,``0@)')
  - [IfAttributes\`\`1(attributes)](#M-Bb-Accessors-AccessorItem-IfAttributes``1-System-Collections-Generic-List{``0}@- 'Bb.Accessors.AccessorItem.IfAttributes``1(System.Collections.Generic.List{``0}@)')
  - [IfAttributes\`\`1(instance,attributes)](#M-Bb-Accessors-AccessorItem-IfAttributes``1-System-Object,System-Collections-Generic-List{``0}@- 'Bb.Accessors.AccessorItem.IfAttributes``1(System.Object,System.Collections.Generic.List{``0}@)')
  - [ResolveName(name)](#M-Bb-Accessors-AccessorItem-ResolveName-System-String- 'Bb.Accessors.AccessorItem.ResolveName(System.String)')
  - [ValidateMember(instance,throwException,attributes)](#M-Bb-Accessors-AccessorItem-ValidateMember-System-Object,System-Boolean,System-Collections-Generic-IEnumerable{System-ComponentModel-DataAnnotations-ValidationAttribute}- 'Bb.Accessors.AccessorItem.ValidateMember(System.Object,System.Boolean,System.Collections.Generic.IEnumerable{System.ComponentModel.DataAnnotations.ValidationAttribute})')
- [AccessorList](#T-Bb-Accessors-AccessorList 'Bb.Accessors.AccessorList')
  - [#ctor()](#M-Bb-Accessors-AccessorList-#ctor 'Bb.Accessors.AccessorList.#ctor')
  - [#ctor(list)](#M-Bb-Accessors-AccessorList-#ctor-System-Collections-Generic-IEnumerable{Bb-Accessors-AccessorItem}- 'Bb.Accessors.AccessorList.#ctor(System.Collections.Generic.IEnumerable{Bb.Accessors.AccessorItem})')
  - [_lock](#F-Bb-Accessors-AccessorList-_lock 'Bb.Accessors.AccessorList._lock')
  - [Count](#P-Bb-Accessors-AccessorList-Count 'Bb.Accessors.AccessorList.Count')
  - [Item](#P-Bb-Accessors-AccessorList-Item-System-String- 'Bb.Accessors.AccessorList.Item(System.String)')
  - [Item](#P-Bb-Accessors-AccessorList-Item-System-Reflection-MemberInfo- 'Bb.Accessors.AccessorList.Item(System.Reflection.MemberInfo)')
  - [Add(propertyAccessor)](#M-Bb-Accessors-AccessorList-Add-Bb-Accessors-AccessorItem- 'Bb.Accessors.AccessorList.Add(Bb.Accessors.AccessorItem)')
  - [ContainsKey(name)](#M-Bb-Accessors-AccessorList-ContainsKey-System-String- 'Bb.Accessors.AccessorList.ContainsKey(System.String)')
  - [Get(memberName)](#M-Bb-Accessors-AccessorList-Get-System-String,System-Boolean- 'Bb.Accessors.AccessorList.Get(System.String,System.Boolean)')
  - [GetEnumerator()](#M-Bb-Accessors-AccessorList-GetEnumerator 'Bb.Accessors.AccessorList.GetEnumerator')
  - [GetProperties(componentType)](#M-Bb-Accessors-AccessorList-GetProperties-System-Type,System-Func{System-Type,System-Boolean}- 'Bb.Accessors.AccessorList.GetProperties(System.Type,System.Func{System.Type,System.Boolean})')
  - [Map(source,target)](#M-Bb-Accessors-AccessorList-Map-System-Object,System-Object- 'Bb.Accessors.AccessorList.Map(System.Object,System.Object)')
  - [Remove(propertyAccessor)](#M-Bb-Accessors-AccessorList-Remove-Bb-Accessors-AccessorItem- 'Bb.Accessors.AccessorList.Remove(Bb.Accessors.AccessorItem)')
  - [Remove(name)](#M-Bb-Accessors-AccessorList-Remove-System-String- 'Bb.Accessors.AccessorList.Remove(System.String)')
  - [System#Collections#IEnumerable#GetEnumerator()](#M-Bb-Accessors-AccessorList-System#Collections#IEnumerable#GetEnumerator 'Bb.Accessors.AccessorList.System#Collections#IEnumerable#GetEnumerator')
  - [TryGetValue(name,member)](#M-Bb-Accessors-AccessorList-TryGetValue-System-String,Bb-Accessors-AccessorItem@- 'Bb.Accessors.AccessorList.TryGetValue(System.String,Bb.Accessors.AccessorItem@)')
  - [Validate(instance)](#M-Bb-Accessors-AccessorList-Validate-System-Object- 'Bb.Accessors.AccessorList.Validate(System.Object)')
  - [ValidateMember(value,member,attributes)](#M-Bb-Accessors-AccessorList-ValidateMember-System-Object,System-Reflection-MemberInfo,System-Collections-Generic-IEnumerable{System-ComponentModel-DataAnnotations-ValidationAttribute}- 'Bb.Accessors.AccessorList.ValidateMember(System.Object,System.Reflection.MemberInfo,System.Collections.Generic.IEnumerable{System.ComponentModel.DataAnnotations.ValidationAttribute})')
- [ConnexionReaderExtension](#T-Bb-Converters-ConnexionReaderExtension 'Bb.Converters.ConnexionReaderExtension')
  - [GetKeyValues(payload)](#M-Bb-Converters-ConnexionReaderExtension-GetKeyValues-System-String- 'Bb.Converters.ConnexionReaderExtension.GetKeyValues(System.String)')
- [ConverterContext](#T-Bb-Converters-ConverterContext 'Bb.Converters.ConverterContext')
  - [#ctor(cultureInfo)](#M-Bb-Converters-ConverterContext-#ctor-System-Globalization-CultureInfo- 'Bb.Converters.ConverterContext.#ctor(System.Globalization.CultureInfo)')
  - [#ctor()](#M-Bb-Converters-ConverterContext-#ctor 'Bb.Converters.ConverterContext.#ctor')
  - [#ctor(cultureInfo,encoding)](#M-Bb-Converters-ConverterContext-#ctor-System-Globalization-CultureInfo,System-Text-Encoding- 'Bb.Converters.ConverterContext.#ctor(System.Globalization.CultureInfo,System.Text.Encoding)')
  - [Culture](#P-Bb-Converters-ConverterContext-Culture 'Bb.Converters.ConverterContext.Culture')
  - [DefaultCultureInfo](#P-Bb-Converters-ConverterContext-DefaultCultureInfo 'Bb.Converters.ConverterContext.DefaultCultureInfo')
  - [Encoding](#P-Bb-Converters-ConverterContext-Encoding 'Bb.Converters.ConverterContext.Encoding')
- [ConverterHelper](#T-Bb-Converters-ConverterHelper 'Bb.Converters.ConverterHelper')
  - [#cctor()](#M-Bb-Converters-ConverterHelper-#cctor 'Bb.Converters.ConverterHelper.#cctor')
  - [AppendConverter(method,replaceExisting)](#M-Bb-Converters-ConverterHelper-AppendConverter-System-Delegate,System-Boolean- 'Bb.Converters.ConverterHelper.AppendConverter(System.Delegate,System.Boolean)')
  - [AppendConverters(type,replaceExisting,bindings)](#M-Bb-Converters-ConverterHelper-AppendConverters-System-Type,System-Nullable{System-Boolean},System-Reflection-BindingFlags,System-Func{System-Reflection-MethodInfo,System-Boolean}- 'Bb.Converters.ConverterHelper.AppendConverters(System.Type,System.Nullable{System.Boolean},System.Reflection.BindingFlags,System.Func{System.Reflection.MethodInfo,System.Boolean})')
  - [AppendConverters(replaceExisting,ms)](#M-Bb-Converters-ConverterHelper-AppendConverters-System-Nullable{System-Boolean},System-Reflection-MethodInfo[]- 'Bb.Converters.ConverterHelper.AppendConverters(System.Nullable{System.Boolean},System.Reflection.MethodInfo[])')
  - [AppendConverters(ms)](#M-Bb-Converters-ConverterHelper-AppendConverters-System-Reflection-ConstructorInfo[]- 'Bb.Converters.ConverterHelper.AppendConverters(System.Reflection.ConstructorInfo[])')
  - [ConvertTo(self,targetType,context)](#M-Bb-Converters-ConverterHelper-ConvertTo-System-Object,System-Type,Bb-Converters-ConverterContext- 'Bb.Converters.ConverterHelper.ConvertTo(System.Object,System.Type,Bb.Converters.ConverterContext)')
  - [ConvertTo(self,targetType)](#M-Bb-Converters-ConverterHelper-ConvertTo-System-Object,System-Type- 'Bb.Converters.ConverterHelper.ConvertTo(System.Object,System.Type)')
  - [ConvertTo(self,targetType,culture)](#M-Bb-Converters-ConverterHelper-ConvertTo-System-Object,System-Type,System-Globalization-CultureInfo- 'Bb.Converters.ConverterHelper.ConvertTo(System.Object,System.Type,System.Globalization.CultureInfo)')
  - [ConvertTo(self,targetType,encoding)](#M-Bb-Converters-ConverterHelper-ConvertTo-System-Object,System-Type,System-Text-Encoding- 'Bb.Converters.ConverterHelper.ConvertTo(System.Object,System.Type,System.Text.Encoding)')
  - [ConvertTo(self,culture,targetType,encoding)](#M-Bb-Converters-ConverterHelper-ConvertTo-System-Object,System-Type,System-Globalization-CultureInfo,System-Text-Encoding- 'Bb.Converters.ConverterHelper.ConvertTo(System.Object,System.Type,System.Globalization.CultureInfo,System.Text.Encoding)')
  - [ConvertTo\`\`1(self)](#M-Bb-Converters-ConverterHelper-ConvertTo``1-System-Object- 'Bb.Converters.ConverterHelper.ConvertTo``1(System.Object)')
  - [ConvertTo\`\`1(self,culture)](#M-Bb-Converters-ConverterHelper-ConvertTo``1-System-Object,System-Globalization-CultureInfo- 'Bb.Converters.ConverterHelper.ConvertTo``1(System.Object,System.Globalization.CultureInfo)')
  - [ConvertTo\`\`1(self,encoding)](#M-Bb-Converters-ConverterHelper-ConvertTo``1-System-Object,System-Text-Encoding- 'Bb.Converters.ConverterHelper.ConvertTo``1(System.Object,System.Text.Encoding)')
  - [ConvertTo\`\`1(self,culture,encoding)](#M-Bb-Converters-ConverterHelper-ConvertTo``1-System-Object,System-Globalization-CultureInfo,System-Text-Encoding- 'Bb.Converters.ConverterHelper.ConvertTo``1(System.Object,System.Globalization.CultureInfo,System.Text.Encoding)')
  - [GetFunctionForConvert(sourceType,targetType)](#M-Bb-Converters-ConverterHelper-GetFunctionForConvert-System-Type,System-Type- 'Bb.Converters.ConverterHelper.GetFunctionForConvert(System.Type,System.Type)')
  - [GetMethodToConvert(sourceType,targetType)](#M-Bb-Converters-ConverterHelper-GetMethodToConvert-System-Type,System-Type- 'Bb.Converters.ConverterHelper.GetMethodToConvert(System.Type,System.Type)')
  - [Methods(filter)](#M-Bb-Converters-ConverterHelper-Methods-System-Predicate{Bb-Converters-MethodTypeConverter}- 'Bb.Converters.ConverterHelper.Methods(System.Predicate{Bb.Converters.MethodTypeConverter})')
  - [Register(newMethod)](#M-Bb-Converters-ConverterHelper-Register-Bb-Converters-MethodConverter- 'Bb.Converters.ConverterHelper.Register(Bb.Converters.MethodConverter)')
  - [Reset(type)](#M-Bb-Converters-ConverterHelper-Reset-System-Type- 'Bb.Converters.ConverterHelper.Reset(System.Type)')
  - [Serialize(value)](#M-Bb-Converters-ConverterHelper-Serialize-System-Object- 'Bb.Converters.ConverterHelper.Serialize(System.Object)')
  - [ToBoolean(self)](#M-Bb-Converters-ConverterHelper-ToBoolean-System-String- 'Bb.Converters.ConverterHelper.ToBoolean(System.String)')
  - [ToBoolean(self)](#M-Bb-Converters-ConverterHelper-ToBoolean-System-Int32- 'Bb.Converters.ConverterHelper.ToBoolean(System.Int32)')
  - [ToByte(value)](#M-Bb-Converters-ConverterHelper-ToByte-System-Char[]- 'Bb.Converters.ConverterHelper.ToByte(System.Char[])')
  - [ToByte(value)](#M-Bb-Converters-ConverterHelper-ToByte-System-Byte[]- 'Bb.Converters.ConverterHelper.ToByte(System.Byte[])')
  - [ToByte(self)](#M-Bb-Converters-ConverterHelper-ToByte-System-Single- 'Bb.Converters.ConverterHelper.ToByte(System.Single)')
  - [ToByteArray(value)](#M-Bb-Converters-ConverterHelper-ToByteArray-System-String- 'Bb.Converters.ConverterHelper.ToByteArray(System.String)')
  - [ToByteArray(value)](#M-Bb-Converters-ConverterHelper-ToByteArray-System-Char[]- 'Bb.Converters.ConverterHelper.ToByteArray(System.Char[])')
  - [ToByteArray(value)](#M-Bb-Converters-ConverterHelper-ToByteArray-System-Char- 'Bb.Converters.ConverterHelper.ToByteArray(System.Char)')
  - [ToByteArray(value)](#M-Bb-Converters-ConverterHelper-ToByteArray-System-Int32- 'Bb.Converters.ConverterHelper.ToByteArray(System.Int32)')
  - [ToChar(self)](#M-Bb-Converters-ConverterHelper-ToChar-System-Single- 'Bb.Converters.ConverterHelper.ToChar(System.Single)')
  - [ToChar(self)](#M-Bb-Converters-ConverterHelper-ToChar-System-Double- 'Bb.Converters.ConverterHelper.ToChar(System.Double)')
  - [ToChar(self)](#M-Bb-Converters-ConverterHelper-ToChar-System-Boolean- 'Bb.Converters.ConverterHelper.ToChar(System.Boolean)')
  - [ToChar(self)](#M-Bb-Converters-ConverterHelper-ToChar-System-Decimal- 'Bb.Converters.ConverterHelper.ToChar(System.Decimal)')
  - [ToChar(self)](#M-Bb-Converters-ConverterHelper-ToChar-System-Int32- 'Bb.Converters.ConverterHelper.ToChar(System.Int32)')
  - [ToChar(value)](#M-Bb-Converters-ConverterHelper-ToChar-System-Byte[]- 'Bb.Converters.ConverterHelper.ToChar(System.Byte[])')
  - [ToChar(value)](#M-Bb-Converters-ConverterHelper-ToChar-System-SByte[]- 'Bb.Converters.ConverterHelper.ToChar(System.SByte[])')
  - [ToChar(value)](#M-Bb-Converters-ConverterHelper-ToChar-System-Char[]- 'Bb.Converters.ConverterHelper.ToChar(System.Char[])')
  - [ToCharArray(value)](#M-Bb-Converters-ConverterHelper-ToCharArray-System-Int32- 'Bb.Converters.ConverterHelper.ToCharArray(System.Int32)')
  - [ToCharArray(value)](#M-Bb-Converters-ConverterHelper-ToCharArray-System-Guid- 'Bb.Converters.ConverterHelper.ToCharArray(System.Guid)')
  - [ToCharArray(value)](#M-Bb-Converters-ConverterHelper-ToCharArray-System-Byte[]- 'Bb.Converters.ConverterHelper.ToCharArray(System.Byte[])')
  - [ToDateTime(value)](#M-Bb-Converters-ConverterHelper-ToDateTime-System-DateTimeOffset- 'Bb.Converters.ConverterHelper.ToDateTime(System.DateTimeOffset)')
  - [ToDateTimeOffser(value)](#M-Bb-Converters-ConverterHelper-ToDateTimeOffser-System-TimeSpan- 'Bb.Converters.ConverterHelper.ToDateTimeOffser(System.TimeSpan)')
  - [ToDateTimeOffset(value,cultureInfo)](#M-Bb-Converters-ConverterHelper-ToDateTimeOffset-System-String,System-Globalization-CultureInfo- 'Bb.Converters.ConverterHelper.ToDateTimeOffset(System.String,System.Globalization.CultureInfo)')
  - [ToDateTimeOffset(value)](#M-Bb-Converters-ConverterHelper-ToDateTimeOffset-System-DateTime- 'Bb.Converters.ConverterHelper.ToDateTimeOffset(System.DateTime)')
  - [ToDateTimeOffset(value)](#M-Bb-Converters-ConverterHelper-ToDateTimeOffset-System-SByte- 'Bb.Converters.ConverterHelper.ToDateTimeOffset(System.SByte)')
  - [ToDateTimeOffset(value)](#M-Bb-Converters-ConverterHelper-ToDateTimeOffset-System-Byte- 'Bb.Converters.ConverterHelper.ToDateTimeOffset(System.Byte)')
  - [ToDateTimeOffset(value)](#M-Bb-Converters-ConverterHelper-ToDateTimeOffset-System-Int16- 'Bb.Converters.ConverterHelper.ToDateTimeOffset(System.Int16)')
  - [ToDateTimeOffset(value)](#M-Bb-Converters-ConverterHelper-ToDateTimeOffset-System-UInt16- 'Bb.Converters.ConverterHelper.ToDateTimeOffset(System.UInt16)')
  - [ToDateTimeOffset(value)](#M-Bb-Converters-ConverterHelper-ToDateTimeOffset-System-Int32- 'Bb.Converters.ConverterHelper.ToDateTimeOffset(System.Int32)')
  - [ToDateTimeOffset(value)](#M-Bb-Converters-ConverterHelper-ToDateTimeOffset-System-UInt32- 'Bb.Converters.ConverterHelper.ToDateTimeOffset(System.UInt32)')
  - [ToDateTimeOffset(value)](#M-Bb-Converters-ConverterHelper-ToDateTimeOffset-System-Int64- 'Bb.Converters.ConverterHelper.ToDateTimeOffset(System.Int64)')
  - [ToDateTimeOffset(value)](#M-Bb-Converters-ConverterHelper-ToDateTimeOffset-System-UInt64- 'Bb.Converters.ConverterHelper.ToDateTimeOffset(System.UInt64)')
  - [ToDateTimeOffset(value)](#M-Bb-Converters-ConverterHelper-ToDateTimeOffset-System-Boolean- 'Bb.Converters.ConverterHelper.ToDateTimeOffset(System.Boolean)')
  - [ToDateTimeOffset(value)](#M-Bb-Converters-ConverterHelper-ToDateTimeOffset-System-Char- 'Bb.Converters.ConverterHelper.ToDateTimeOffset(System.Char)')
  - [ToDateTimeOffset(value)](#M-Bb-Converters-ConverterHelper-ToDateTimeOffset-System-Single- 'Bb.Converters.ConverterHelper.ToDateTimeOffset(System.Single)')
  - [ToDateTimeOffset(value)](#M-Bb-Converters-ConverterHelper-ToDateTimeOffset-System-Double- 'Bb.Converters.ConverterHelper.ToDateTimeOffset(System.Double)')
  - [ToDateTimeOffset(value)](#M-Bb-Converters-ConverterHelper-ToDateTimeOffset-System-Decimal- 'Bb.Converters.ConverterHelper.ToDateTimeOffset(System.Decimal)')
  - [ToDecimal(value)](#M-Bb-Converters-ConverterHelper-ToDecimal-System-Char- 'Bb.Converters.ConverterHelper.ToDecimal(System.Char)')
  - [ToDictionaryObject(self)](#M-Bb-Converters-ConverterHelper-ToDictionaryObject-System-String- 'Bb.Converters.ConverterHelper.ToDictionaryObject(System.String)')
  - [ToDictionaryString(self)](#M-Bb-Converters-ConverterHelper-ToDictionaryString-System-String- 'Bb.Converters.ConverterHelper.ToDictionaryString(System.String)')
  - [ToDouble(value)](#M-Bb-Converters-ConverterHelper-ToDouble-System-Char- 'Bb.Converters.ConverterHelper.ToDouble(System.Char)')
  - [ToGuid(value)](#M-Bb-Converters-ConverterHelper-ToGuid-System-Char[]- 'Bb.Converters.ConverterHelper.ToGuid(System.Char[])')
  - [ToInt16(value)](#M-Bb-Converters-ConverterHelper-ToInt16-System-Single- 'Bb.Converters.ConverterHelper.ToInt16(System.Single)')
  - [ToInt16(value)](#M-Bb-Converters-ConverterHelper-ToInt16-System-Double- 'Bb.Converters.ConverterHelper.ToInt16(System.Double)')
  - [ToInt16(value)](#M-Bb-Converters-ConverterHelper-ToInt16-System-Char- 'Bb.Converters.ConverterHelper.ToInt16(System.Char)')
  - [ToInt32(value)](#M-Bb-Converters-ConverterHelper-ToInt32-System-Single- 'Bb.Converters.ConverterHelper.ToInt32(System.Single)')
  - [ToInt32(value)](#M-Bb-Converters-ConverterHelper-ToInt32-System-Double- 'Bb.Converters.ConverterHelper.ToInt32(System.Double)')
  - [ToInt32(value)](#M-Bb-Converters-ConverterHelper-ToInt32-System-Char- 'Bb.Converters.ConverterHelper.ToInt32(System.Char)')
  - [ToInt64(value)](#M-Bb-Converters-ConverterHelper-ToInt64-System-Single- 'Bb.Converters.ConverterHelper.ToInt64(System.Single)')
  - [ToInt64(value)](#M-Bb-Converters-ConverterHelper-ToInt64-System-Double- 'Bb.Converters.ConverterHelper.ToInt64(System.Double)')
  - [ToInt64(value)](#M-Bb-Converters-ConverterHelper-ToInt64-System-Char- 'Bb.Converters.ConverterHelper.ToInt64(System.Char)')
  - [ToSByte(value)](#M-Bb-Converters-ConverterHelper-ToSByte-System-Char[]- 'Bb.Converters.ConverterHelper.ToSByte(System.Char[])')
  - [ToSByte(value)](#M-Bb-Converters-ConverterHelper-ToSByte-System-Byte[]- 'Bb.Converters.ConverterHelper.ToSByte(System.Byte[])')
  - [ToSByte(value)](#M-Bb-Converters-ConverterHelper-ToSByte-System-SByte[]- 'Bb.Converters.ConverterHelper.ToSByte(System.SByte[])')
  - [ToSingle(value)](#M-Bb-Converters-ConverterHelper-ToSingle-System-Char- 'Bb.Converters.ConverterHelper.ToSingle(System.Char)')
  - [ToString(value)](#M-Bb-Converters-ConverterHelper-ToString-System-Guid- 'Bb.Converters.ConverterHelper.ToString(System.Guid)')
  - [ToString(self)](#M-Bb-Converters-ConverterHelper-ToString-System-Char[]- 'Bb.Converters.ConverterHelper.ToString(System.Char[])')
  - [ToString(self)](#M-Bb-Converters-ConverterHelper-ToString-System-Byte[]- 'Bb.Converters.ConverterHelper.ToString(System.Byte[])')
  - [ToTimeSpan(value)](#M-Bb-Converters-ConverterHelper-ToTimeSpan-System-DateTime- 'Bb.Converters.ConverterHelper.ToTimeSpan(System.DateTime)')
  - [ToTimeSpan(value)](#M-Bb-Converters-ConverterHelper-ToTimeSpan-System-DateTimeOffset- 'Bb.Converters.ConverterHelper.ToTimeSpan(System.DateTimeOffset)')
  - [TryGetMethodToConvert(sourceType,targetType,method)](#M-Bb-Converters-ConverterHelper-TryGetMethodToConvert-System-Type,System-Type,Bb-Converters-MethodConverter@- 'Bb.Converters.ConverterHelper.TryGetMethodToConvert(System.Type,System.Type,Bb.Converters.MethodConverter@)')
  - [Unserialize(value,type)](#M-Bb-Converters-ConverterHelper-Unserialize-System-String,System-Type- 'Bb.Converters.ConverterHelper.Unserialize(System.String,System.Type)')
- [ConverterMoreNullable](#T-Bb-Converters-ConverterMoreNullable 'Bb.Converters.ConverterMoreNullable')
  - [ToDateTime(value)](#M-Bb-Converters-ConverterMoreNullable-ToDateTime-System-DateTimeOffset- 'Bb.Converters.ConverterMoreNullable.ToDateTime(System.DateTimeOffset)')
  - [ToDateTime(value)](#M-Bb-Converters-ConverterMoreNullable-ToDateTime-System-Nullable{System-DateTimeOffset}- 'Bb.Converters.ConverterMoreNullable.ToDateTime(System.Nullable{System.DateTimeOffset})')
  - [ToDateTimeOffset(value)](#M-Bb-Converters-ConverterMoreNullable-ToDateTimeOffset-System-DateTime- 'Bb.Converters.ConverterMoreNullable.ToDateTimeOffset(System.DateTime)')
  - [ToDateTimeOffset(value,cultureInfo)](#M-Bb-Converters-ConverterMoreNullable-ToDateTimeOffset-System-String,System-Globalization-CultureInfo- 'Bb.Converters.ConverterMoreNullable.ToDateTimeOffset(System.String,System.Globalization.CultureInfo)')
- [Converter\`1](#T-Bb-Converters-Converter`1 'Bb.Converters.Converter`1')
  - [Format](#P-Bb-Converters-Converter`1-Format 'Bb.Converters.Converter`1.Format')
- [Converter\`2](#T-Bb-Converters-Converter`2 'Bb.Converters.Converter`2')
  - [Culture](#P-Bb-Converters-Converter`2-Culture 'Bb.Converters.Converter`2.Culture')
- [DisposedEventHandler](#T-Bb-DisposedEventHandler 'Bb.DisposedEventHandler')
- [ExpressionHelper](#T-Bb-Expressions-ExpressionHelper 'Bb.Expressions.ExpressionHelper')
  - [Add(left,right)](#M-Bb-Expressions-ExpressionHelper-Add-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression- 'Bb.Expressions.ExpressionHelper.Add(System.Linq.Expressions.Expression,System.Linq.Expressions.Expression)')
  - [AddAssign(left,right)](#M-Bb-Expressions-ExpressionHelper-AddAssign-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression- 'Bb.Expressions.ExpressionHelper.AddAssign(System.Linq.Expressions.Expression,System.Linq.Expressions.Expression)')
  - [ArrayIndex(self,index)](#M-Bb-Expressions-ExpressionHelper-ArrayIndex-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression- 'Bb.Expressions.ExpressionHelper.ArrayIndex(System.Linq.Expressions.Expression,System.Linq.Expressions.Expression)')
  - [AsConstant(self,type)](#M-Bb-Expressions-ExpressionHelper-AsConstant-System-Object,System-Type- 'Bb.Expressions.ExpressionHelper.AsConstant(System.Object,System.Type)')
  - [AssignFrom(left,right)](#M-Bb-Expressions-ExpressionHelper-AssignFrom-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression- 'Bb.Expressions.ExpressionHelper.AssignFrom(System.Linq.Expressions.Expression,System.Linq.Expressions.Expression)')
  - [Call(self,methodName,arguments)](#M-Bb-Expressions-ExpressionHelper-Call-System-Linq-Expressions-Expression,System-String,System-Linq-Expressions-Expression[]- 'Bb.Expressions.ExpressionHelper.Call(System.Linq.Expressions.Expression,System.String,System.Linq.Expressions.Expression[])')
  - [Call(self,type,methodName,arguments)](#M-Bb-Expressions-ExpressionHelper-Call-System-Linq-Expressions-Expression,System-Type,System-String,System-Linq-Expressions-Expression[]- 'Bb.Expressions.ExpressionHelper.Call(System.Linq.Expressions.Expression,System.Type,System.String,System.Linq.Expressions.Expression[])')
  - [Call(self,methodTarget,arguments)](#M-Bb-Expressions-ExpressionHelper-Call-System-Linq-Expressions-Expression,System-Reflection-MethodInfo,System-Linq-Expressions-Expression[]- 'Bb.Expressions.ExpressionHelper.Call(System.Linq.Expressions.Expression,System.Reflection.MethodInfo,System.Linq.Expressions.Expression[])')
  - [Call(self,arguments)](#M-Bb-Expressions-ExpressionHelper-Call-System-Reflection-MethodInfo,System-Linq-Expressions-Expression[]- 'Bb.Expressions.ExpressionHelper.Call(System.Reflection.MethodInfo,System.Linq.Expressions.Expression[])')
  - [CallIsAssignableFrom(left,right)](#M-Bb-Expressions-ExpressionHelper-CallIsAssignableFrom-System-Type,System-Linq-Expressions-Expression- 'Bb.Expressions.ExpressionHelper.CallIsAssignableFrom(System.Type,System.Linq.Expressions.Expression)')
  - [CallIsAssignableFrom(left,right)](#M-Bb-Expressions-ExpressionHelper-CallIsAssignableFrom-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression- 'Bb.Expressions.ExpressionHelper.CallIsAssignableFrom(System.Linq.Expressions.Expression,System.Linq.Expressions.Expression)')
  - [CallIsAssignableTo(left,right)](#M-Bb-Expressions-ExpressionHelper-CallIsAssignableTo-System-Type,System-Linq-Expressions-Expression- 'Bb.Expressions.ExpressionHelper.CallIsAssignableTo(System.Type,System.Linq.Expressions.Expression)')
  - [CallIsAssignableTo(left,right)](#M-Bb-Expressions-ExpressionHelper-CallIsAssignableTo-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression- 'Bb.Expressions.ExpressionHelper.CallIsAssignableTo(System.Linq.Expressions.Expression,System.Linq.Expressions.Expression)')
  - [CallStatic(self,arguments)](#M-Bb-Expressions-ExpressionHelper-CallStatic-System-Reflection-MethodInfo,System-Linq-Expressions-Expression[]- 'Bb.Expressions.ExpressionHelper.CallStatic(System.Reflection.MethodInfo,System.Linq.Expressions.Expression[])')
  - [CanBeConverted(targetType,sourceType)](#M-Bb-Expressions-ExpressionHelper-CanBeConverted-System-Type,System-Type- 'Bb.Expressions.ExpressionHelper.CanBeConverted(System.Type,System.Type)')
  - [Coalesce(left,right)](#M-Bb-Expressions-ExpressionHelper-Coalesce-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression- 'Bb.Expressions.ExpressionHelper.Coalesce(System.Linq.Expressions.Expression,System.Linq.Expressions.Expression)')
  - [ConvertIfDifferent(self,targetType)](#M-Bb-Expressions-ExpressionHelper-ConvertIfDifferent-System-Linq-Expressions-Expression,System-Type,System-Linq-Expressions-ParameterExpression- 'Bb.Expressions.ExpressionHelper.ConvertIfDifferent(System.Linq.Expressions.Expression,System.Type,System.Linq.Expressions.ParameterExpression)')
  - [CreateObject(type,args)](#M-Bb-Expressions-ExpressionHelper-CreateObject-System-Type,System-Linq-Expressions-Expression[]- 'Bb.Expressions.ExpressionHelper.CreateObject(System.Type,System.Linq.Expressions.Expression[])')
  - [CreateObject(ctor,args)](#M-Bb-Expressions-ExpressionHelper-CreateObject-System-Reflection-ConstructorInfo,System-Linq-Expressions-Expression[]- 'Bb.Expressions.ExpressionHelper.CreateObject(System.Reflection.ConstructorInfo,System.Linq.Expressions.Expression[])')
  - [Decrement(left)](#M-Bb-Expressions-ExpressionHelper-Decrement-System-Linq-Expressions-Expression- 'Bb.Expressions.ExpressionHelper.Decrement(System.Linq.Expressions.Expression)')
  - [DefaultValue(self)](#M-Bb-Expressions-ExpressionHelper-DefaultValue-System-Type- 'Bb.Expressions.ExpressionHelper.DefaultValue(System.Type)')
  - [Divide(left,right)](#M-Bb-Expressions-ExpressionHelper-Divide-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression- 'Bb.Expressions.ExpressionHelper.Divide(System.Linq.Expressions.Expression,System.Linq.Expressions.Expression)')
  - [DivideAssign(left,right)](#M-Bb-Expressions-ExpressionHelper-DivideAssign-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression- 'Bb.Expressions.ExpressionHelper.DivideAssign(System.Linq.Expressions.Expression,System.Linq.Expressions.Expression)')
  - [Equal(left,right)](#M-Bb-Expressions-ExpressionHelper-Equal-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression- 'Bb.Expressions.ExpressionHelper.Equal(System.Linq.Expressions.Expression,System.Linq.Expressions.Expression)')
  - [ExclusiveOr(left,right)](#M-Bb-Expressions-ExpressionHelper-ExclusiveOr-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression- 'Bb.Expressions.ExpressionHelper.ExclusiveOr(System.Linq.Expressions.Expression,System.Linq.Expressions.Expression)')
  - [ExclusiveOrAssign(left,right)](#M-Bb-Expressions-ExpressionHelper-ExclusiveOrAssign-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression- 'Bb.Expressions.ExpressionHelper.ExclusiveOrAssign(System.Linq.Expressions.Expression,System.Linq.Expressions.Expression)')
  - [Field(self,fieldName)](#M-Bb-Expressions-ExpressionHelper-Field-System-Linq-Expressions-Expression,System-String- 'Bb.Expressions.ExpressionHelper.Field(System.Linq.Expressions.Expression,System.String)')
  - [Field(self,fieldName,binding)](#M-Bb-Expressions-ExpressionHelper-Field-System-Linq-Expressions-Expression,System-String,System-Reflection-BindingFlags- 'Bb.Expressions.ExpressionHelper.Field(System.Linq.Expressions.Expression,System.String,System.Reflection.BindingFlags)')
  - [Field(self,field)](#M-Bb-Expressions-ExpressionHelper-Field-System-Linq-Expressions-Expression,System-Reflection-FieldInfo- 'Bb.Expressions.ExpressionHelper.Field(System.Linq.Expressions.Expression,System.Reflection.FieldInfo)')
  - [GetBestMethod(arguments,methods)](#M-Bb-Expressions-ExpressionHelper-GetBestMethod-System-Linq-Expressions-Expression[],System-Collections-Generic-List{System-Reflection-MethodInfo}- 'Bb.Expressions.ExpressionHelper.GetBestMethod(System.Linq.Expressions.Expression[],System.Collections.Generic.List{System.Reflection.MethodInfo})')
  - [GetBestMethod(types,methods)](#M-Bb-Expressions-ExpressionHelper-GetBestMethod-System-Type[],System-Collections-Generic-List{System-Reflection-MethodInfo}- 'Bb.Expressions.ExpressionHelper.GetBestMethod(System.Type[],System.Collections.Generic.List{System.Reflection.MethodInfo})')
  - [GetFieldName(expression)](#M-Bb-Expressions-ExpressionHelper-GetFieldName-System-Linq-Expressions-Expression- 'Bb.Expressions.ExpressionHelper.GetFieldName(System.Linq.Expressions.Expression)')
  - [GetPropertyName(expression)](#M-Bb-Expressions-ExpressionHelper-GetPropertyName-System-Linq-Expressions-Expression- 'Bb.Expressions.ExpressionHelper.GetPropertyName(System.Linq.Expressions.Expression)')
  - [GreaterThan(left,right)](#M-Bb-Expressions-ExpressionHelper-GreaterThan-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression- 'Bb.Expressions.ExpressionHelper.GreaterThan(System.Linq.Expressions.Expression,System.Linq.Expressions.Expression)')
  - [GreaterThanOrEqual(left,right)](#M-Bb-Expressions-ExpressionHelper-GreaterThanOrEqual-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression- 'Bb.Expressions.ExpressionHelper.GreaterThanOrEqual(System.Linq.Expressions.Expression,System.Linq.Expressions.Expression)')
  - [Increment(left)](#M-Bb-Expressions-ExpressionHelper-Increment-System-Linq-Expressions-Expression- 'Bb.Expressions.ExpressionHelper.Increment(System.Linq.Expressions.Expression)')
  - [IsFalse(left)](#M-Bb-Expressions-ExpressionHelper-IsFalse-System-Linq-Expressions-Expression- 'Bb.Expressions.ExpressionHelper.IsFalse(System.Linq.Expressions.Expression)')
  - [IsTrue(left)](#M-Bb-Expressions-ExpressionHelper-IsTrue-System-Linq-Expressions-Expression- 'Bb.Expressions.ExpressionHelper.IsTrue(System.Linq.Expressions.Expression)')
  - [Loop(body)](#M-Bb-Expressions-ExpressionHelper-Loop-System-Linq-Expressions-Expression- 'Bb.Expressions.ExpressionHelper.Loop(System.Linq.Expressions.Expression)')
  - [Modulo(left,right)](#M-Bb-Expressions-ExpressionHelper-Modulo-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression- 'Bb.Expressions.ExpressionHelper.Modulo(System.Linq.Expressions.Expression,System.Linq.Expressions.Expression)')
  - [ModuloAssign(left,right)](#M-Bb-Expressions-ExpressionHelper-ModuloAssign-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression- 'Bb.Expressions.ExpressionHelper.ModuloAssign(System.Linq.Expressions.Expression,System.Linq.Expressions.Expression)')
  - [Multiply(left,right)](#M-Bb-Expressions-ExpressionHelper-Multiply-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression- 'Bb.Expressions.ExpressionHelper.Multiply(System.Linq.Expressions.Expression,System.Linq.Expressions.Expression)')
  - [MultiplyAssign(left,right)](#M-Bb-Expressions-ExpressionHelper-MultiplyAssign-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression- 'Bb.Expressions.ExpressionHelper.MultiplyAssign(System.Linq.Expressions.Expression,System.Linq.Expressions.Expression)')
  - [Negate(left)](#M-Bb-Expressions-ExpressionHelper-Negate-System-Linq-Expressions-Expression- 'Bb.Expressions.ExpressionHelper.Negate(System.Linq.Expressions.Expression)')
  - [NewArray(self,expressions)](#M-Bb-Expressions-ExpressionHelper-NewArray-System-Type,System-Collections-Generic-IEnumerable{System-Linq-Expressions-Expression}- 'Bb.Expressions.ExpressionHelper.NewArray(System.Type,System.Collections.Generic.IEnumerable{System.Linq.Expressions.Expression})')
  - [NewArray(self,expressions)](#M-Bb-Expressions-ExpressionHelper-NewArray-System-Type,System-Linq-Expressions-Expression[]- 'Bb.Expressions.ExpressionHelper.NewArray(System.Type,System.Linq.Expressions.Expression[])')
  - [Not(left)](#M-Bb-Expressions-ExpressionHelper-Not-System-Linq-Expressions-Expression- 'Bb.Expressions.ExpressionHelper.Not(System.Linq.Expressions.Expression)')
  - [NotEqual(left,right)](#M-Bb-Expressions-ExpressionHelper-NotEqual-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression- 'Bb.Expressions.ExpressionHelper.NotEqual(System.Linq.Expressions.Expression,System.Linq.Expressions.Expression)')
  - [Or(left,right)](#M-Bb-Expressions-ExpressionHelper-Or-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression- 'Bb.Expressions.ExpressionHelper.Or(System.Linq.Expressions.Expression,System.Linq.Expressions.Expression)')
  - [OrAssign(left,right)](#M-Bb-Expressions-ExpressionHelper-OrAssign-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression- 'Bb.Expressions.ExpressionHelper.OrAssign(System.Linq.Expressions.Expression,System.Linq.Expressions.Expression)')
  - [OrElse(left,right)](#M-Bb-Expressions-ExpressionHelper-OrElse-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression- 'Bb.Expressions.ExpressionHelper.OrElse(System.Linq.Expressions.Expression,System.Linq.Expressions.Expression)')
  - [OrderMethods(methods,type)](#M-Bb-Expressions-ExpressionHelper-OrderMethods-System-Collections-Generic-List{System-Reflection-MethodInfo},System-Type- 'Bb.Expressions.ExpressionHelper.OrderMethods(System.Collections.Generic.List{System.Reflection.MethodInfo},System.Type)')
  - [PostDecrementAssign(left)](#M-Bb-Expressions-ExpressionHelper-PostDecrementAssign-System-Linq-Expressions-Expression- 'Bb.Expressions.ExpressionHelper.PostDecrementAssign(System.Linq.Expressions.Expression)')
  - [PostIncrementAssign(left)](#M-Bb-Expressions-ExpressionHelper-PostIncrementAssign-System-Linq-Expressions-Expression- 'Bb.Expressions.ExpressionHelper.PostIncrementAssign(System.Linq.Expressions.Expression)')
  - [Power(left,right)](#M-Bb-Expressions-ExpressionHelper-Power-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression- 'Bb.Expressions.ExpressionHelper.Power(System.Linq.Expressions.Expression,System.Linq.Expressions.Expression)')
  - [PowerAssign(left,right)](#M-Bb-Expressions-ExpressionHelper-PowerAssign-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression- 'Bb.Expressions.ExpressionHelper.PowerAssign(System.Linq.Expressions.Expression,System.Linq.Expressions.Expression)')
  - [PreDecrementAssign(left)](#M-Bb-Expressions-ExpressionHelper-PreDecrementAssign-System-Linq-Expressions-Expression- 'Bb.Expressions.ExpressionHelper.PreDecrementAssign(System.Linq.Expressions.Expression)')
  - [PreIncrementAssign(left)](#M-Bb-Expressions-ExpressionHelper-PreIncrementAssign-System-Linq-Expressions-Expression- 'Bb.Expressions.ExpressionHelper.PreIncrementAssign(System.Linq.Expressions.Expression)')
  - [Property(self,propertyName)](#M-Bb-Expressions-ExpressionHelper-Property-System-Linq-Expressions-Expression,System-String- 'Bb.Expressions.ExpressionHelper.Property(System.Linq.Expressions.Expression,System.String)')
  - [Property(self,propertyName,binding)](#M-Bb-Expressions-ExpressionHelper-Property-System-Linq-Expressions-Expression,System-String,System-Reflection-BindingFlags- 'Bb.Expressions.ExpressionHelper.Property(System.Linq.Expressions.Expression,System.String,System.Reflection.BindingFlags)')
  - [Property(self,property)](#M-Bb-Expressions-ExpressionHelper-Property-System-Linq-Expressions-Expression,System-Reflection-PropertyInfo- 'Bb.Expressions.ExpressionHelper.Property(System.Linq.Expressions.Expression,System.Reflection.PropertyInfo)')
  - [ResolveType(self)](#M-Bb-Expressions-ExpressionHelper-ResolveType-System-Linq-Expressions-Expression- 'Bb.Expressions.ExpressionHelper.ResolveType(System.Linq.Expressions.Expression)')
  - [RightShift(left,right)](#M-Bb-Expressions-ExpressionHelper-RightShift-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression- 'Bb.Expressions.ExpressionHelper.RightShift(System.Linq.Expressions.Expression,System.Linq.Expressions.Expression)')
  - [RightShiftAssign(left,right)](#M-Bb-Expressions-ExpressionHelper-RightShiftAssign-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression- 'Bb.Expressions.ExpressionHelper.RightShiftAssign(System.Linq.Expressions.Expression,System.Linq.Expressions.Expression)')
  - [SortBestMethod(arguments,methods)](#M-Bb-Expressions-ExpressionHelper-SortBestMethod-System-Linq-Expressions-Expression[],System-Collections-Generic-List{System-Reflection-MethodInfo}- 'Bb.Expressions.ExpressionHelper.SortBestMethod(System.Linq.Expressions.Expression[],System.Collections.Generic.List{System.Reflection.MethodInfo})')
  - [SortBestMethod(types,methods)](#M-Bb-Expressions-ExpressionHelper-SortBestMethod-System-Type[],System-Collections-Generic-List{System-Reflection-MethodInfo}- 'Bb.Expressions.ExpressionHelper.SortBestMethod(System.Type[],System.Collections.Generic.List{System.Reflection.MethodInfo})')
  - [Subtract(left,right)](#M-Bb-Expressions-ExpressionHelper-Subtract-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression- 'Bb.Expressions.ExpressionHelper.Subtract(System.Linq.Expressions.Expression,System.Linq.Expressions.Expression)')
  - [SubtractAssign(left,right)](#M-Bb-Expressions-ExpressionHelper-SubtractAssign-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression- 'Bb.Expressions.ExpressionHelper.SubtractAssign(System.Linq.Expressions.Expression,System.Linq.Expressions.Expression)')
  - [Throw(type,args)](#M-Bb-Expressions-ExpressionHelper-Throw-System-Type,System-Linq-Expressions-Expression[]- 'Bb.Expressions.ExpressionHelper.Throw(System.Type,System.Linq.Expressions.Expression[])')
  - [TypeAs(left,type)](#M-Bb-Expressions-ExpressionHelper-TypeAs-System-Linq-Expressions-Expression,System-Type- 'Bb.Expressions.ExpressionHelper.TypeAs(System.Linq.Expressions.Expression,System.Type)')
  - [TypeAsConstant(self)](#M-Bb-Expressions-ExpressionHelper-TypeAsConstant-System-Type- 'Bb.Expressions.ExpressionHelper.TypeAsConstant(System.Type)')
  - [TypeEqual(left,type)](#M-Bb-Expressions-ExpressionHelper-TypeEqual-System-Linq-Expressions-Expression,System-Type- 'Bb.Expressions.ExpressionHelper.TypeEqual(System.Linq.Expressions.Expression,System.Type)')
  - [TypeIs(left,type)](#M-Bb-Expressions-ExpressionHelper-TypeIs-System-Linq-Expressions-Expression,System-Type- 'Bb.Expressions.ExpressionHelper.TypeIs(System.Linq.Expressions.Expression,System.Type)')
- [ExpressionMemberVisitor](#T-Bb-Expressions-ExpressionMemberVisitor 'Bb.Expressions.ExpressionMemberVisitor')
  - [GetPropertyName(e)](#M-Bb-Expressions-ExpressionMemberVisitor-GetPropertyName-System-Linq-Expressions-Expression- 'Bb.Expressions.ExpressionMemberVisitor.GetPropertyName(System.Linq.Expressions.Expression)')
- [FieldAccessor](#T-Bb-Accessors-FieldAccessor 'Bb.Accessors.FieldAccessor')
  - [#ctor(componentType,field)](#M-Bb-Accessors-FieldAccessor-#ctor-System-Type,System-Reflection-FieldInfo,Bb-Accessors-MemberStrategy- 'Bb.Accessors.FieldAccessor.#ctor(System.Type,System.Reflection.FieldInfo,Bb.Accessors.MemberStrategy)')
- [IDisposed](#T-Bb-IDisposed 'Bb.IDisposed')
- [IUIComponent](#T-Bb-ComponentModel-IUIComponent 'Bb.ComponentModel.IUIComponent')
  - [GetService(type)](#M-Bb-ComponentModel-IUIComponent-GetService-System-Type- 'Bb.ComponentModel.IUIComponent.GetService(System.Type)')
- [IUISite](#T-Bb-ComponentModel-IUISite 'Bb.ComponentModel.IUISite')
  - [Parent](#P-Bb-ComponentModel-IUISite-Parent 'Bb.ComponentModel.IUISite.Parent')
- [InstanceBinder\`2](#T-Bb-Binders-InstanceBinder`2 'Bb.Binders.InstanceBinder`2')
  - [#ctor(configuration)](#M-Bb-Binders-InstanceBinder`2-#ctor-Bb-Binders-PropertyBinder{`0,`1}- 'Bb.Binders.InstanceBinder`2.#ctor(Bb.Binders.PropertyBinder{`0,`1})')
  - [Bind(source,target)](#M-Bb-Binders-InstanceBinder`2-Bind-`0,`1- 'Bb.Binders.InstanceBinder`2.Bind(`0,`1)')
  - [Dispose()](#M-Bb-Binders-InstanceBinder`2-Dispose 'Bb.Binders.InstanceBinder`2.Dispose')
- [MemberStrategy](#T-Bb-Accessors-MemberStrategy 'Bb.Accessors.MemberStrategy')
  - [ConvertIfDifferent](#F-Bb-Accessors-MemberStrategy-ConvertIfDifferent 'Bb.Accessors.MemberStrategy.ConvertIfDifferent')
  - [Direct](#F-Bb-Accessors-MemberStrategy-Direct 'Bb.Accessors.MemberStrategy.Direct')
  - [Fields](#F-Bb-Accessors-MemberStrategy-Fields 'Bb.Accessors.MemberStrategy.Fields')
  - [Instance](#F-Bb-Accessors-MemberStrategy-Instance 'Bb.Accessors.MemberStrategy.Instance')
  - [NotPublicFields](#F-Bb-Accessors-MemberStrategy-NotPublicFields 'Bb.Accessors.MemberStrategy.NotPublicFields')
  - [Properties](#F-Bb-Accessors-MemberStrategy-Properties 'Bb.Accessors.MemberStrategy.Properties')
  - [Static](#F-Bb-Accessors-MemberStrategy-Static 'Bb.Accessors.MemberStrategy.Static')
- [MemberTypeEnum](#T-Bb-Accessors-MemberTypeEnum 'Bb.Accessors.MemberTypeEnum')
  - [Field](#F-Bb-Accessors-MemberTypeEnum-Field 'Bb.Accessors.MemberTypeEnum.Field')
  - [Property](#F-Bb-Accessors-MemberTypeEnum-Property 'Bb.Accessors.MemberTypeEnum.Property')
- [MethodConverter](#T-Bb-Converters-MethodConverter 'Bb.Converters.MethodConverter')
  - [#ctor(delegate)](#M-Bb-Converters-MethodConverter-#ctor-System-Delegate- 'Bb.Converters.MethodConverter.#ctor(System.Delegate)')
  - [#ctor(method)](#M-Bb-Converters-MethodConverter-#ctor-System-Reflection-ConstructorInfo- 'Bb.Converters.MethodConverter.#ctor(System.Reflection.ConstructorInfo)')
  - [#ctor(method)](#M-Bb-Converters-MethodConverter-#ctor-System-Reflection-MethodInfo- 'Bb.Converters.MethodConverter.#ctor(System.Reflection.MethodInfo)')
  - [Case](#P-Bb-Converters-MethodConverter-Case 'Bb.Converters.MethodConverter.Case')
  - [IsGenericConverter](#P-Bb-Converters-MethodConverter-IsGenericConverter 'Bb.Converters.MethodConverter.IsGenericConverter')
  - [IsStatic](#P-Bb-Converters-MethodConverter-IsStatic 'Bb.Converters.MethodConverter.IsStatic')
  - [Method](#P-Bb-Converters-MethodConverter-Method 'Bb.Converters.MethodConverter.Method')
  - [Parameter0](#P-Bb-Converters-MethodConverter-Parameter0 'Bb.Converters.MethodConverter.Parameter0')
  - [Parameter1](#P-Bb-Converters-MethodConverter-Parameter1 'Bb.Converters.MethodConverter.Parameter1')
  - [ReplaceExistings](#P-Bb-Converters-MethodConverter-ReplaceExistings 'Bb.Converters.MethodConverter.ReplaceExistings')
  - [SourceType](#P-Bb-Converters-MethodConverter-SourceType 'Bb.Converters.MethodConverter.SourceType')
  - [TargetType](#P-Bb-Converters-MethodConverter-TargetType 'Bb.Converters.MethodConverter.TargetType')
  - [ToAdd](#P-Bb-Converters-MethodConverter-ToAdd 'Bb.Converters.MethodConverter.ToAdd')
  - [Equals(obj)](#M-Bb-Converters-MethodConverter-Equals-System-Object- 'Bb.Converters.MethodConverter.Equals(System.Object)')
  - [GetHashCode()](#M-Bb-Converters-MethodConverter-GetHashCode 'Bb.Converters.MethodConverter.GetHashCode')
  - [ToString()](#M-Bb-Converters-MethodConverter-ToString 'Bb.Converters.MethodConverter.ToString')
  - [op_Implicit(delegate)](#M-Bb-Converters-MethodConverter-op_Implicit-System-Delegate-~Bb-Converters-MethodConverter 'Bb.Converters.MethodConverter.op_Implicit(System.Delegate)~Bb.Converters.MethodConverter')
  - [op_Implicit(method)](#M-Bb-Converters-MethodConverter-op_Implicit-System-Reflection-MethodInfo-~Bb-Converters-MethodConverter 'Bb.Converters.MethodConverter.op_Implicit(System.Reflection.MethodInfo)~Bb.Converters.MethodConverter')
  - [op_Implicit(method)](#M-Bb-Converters-MethodConverter-op_Implicit-System-Reflection-ConstructorInfo-~Bb-Converters-MethodConverter 'Bb.Converters.MethodConverter.op_Implicit(System.Reflection.ConstructorInfo)~Bb.Converters.MethodConverter')
- [MethodTypeConverter](#T-Bb-Converters-MethodTypeConverter 'Bb.Converters.MethodTypeConverter')
  - [#ctor(type)](#M-Bb-Converters-MethodTypeConverter-#ctor-System-Type- 'Bb.Converters.MethodTypeConverter.#ctor(System.Type)')
  - [Item](#P-Bb-Converters-MethodTypeConverter-Item-System-Type- 'Bb.Converters.MethodTypeConverter.Item(System.Type)')
  - [SourceType](#P-Bb-Converters-MethodTypeConverter-SourceType 'Bb.Converters.MethodTypeConverter.SourceType')
  - [Add(newMethod)](#M-Bb-Converters-MethodTypeConverter-Add-Bb-Converters-MethodConverter- 'Bb.Converters.MethodTypeConverter.Add(Bb.Converters.MethodConverter)')
  - [AddFunction(targetType,func)](#M-Bb-Converters-MethodTypeConverter-AddFunction-System-Type,System-Func{System-Object,Bb-Converters-ConverterContext,System-Object}- 'Bb.Converters.MethodTypeConverter.AddFunction(System.Type,System.Func{System.Object,Bb.Converters.ConverterContext,System.Object})')
  - [Functions()](#M-Bb-Converters-MethodTypeConverter-Functions 'Bb.Converters.MethodTypeConverter.Functions')
  - [TryGetFunction(targetType,result)](#M-Bb-Converters-MethodTypeConverter-TryGetFunction-System-Type,System-Func{System-Object,Bb-Converters-ConverterContext,System-Object}@- 'Bb.Converters.MethodTypeConverter.TryGetFunction(System.Type,System.Func{System.Object,Bb.Converters.ConverterContext,System.Object}@)')
  - [TryGetValue(key,value)](#M-Bb-Converters-MethodTypeConverter-TryGetValue-System-Type,System-Collections-Generic-List{Bb-Converters-MethodConverter}@- 'Bb.Converters.MethodTypeConverter.TryGetValue(System.Type,System.Collections.Generic.List{Bb.Converters.MethodConverter}@)')
- [PrivatedIndex](#T-Bb-Expressions-PrivatedIndex 'Bb.Expressions.PrivatedIndex')
  - [GetNewIndex()](#M-Bb-Expressions-PrivatedIndex-GetNewIndex 'Bb.Expressions.PrivatedIndex.GetNewIndex')
- [PropertyAccessor](#T-Bb-Accessors-PropertyAccessor 'Bb.Accessors.PropertyAccessor')
  - [#ctor(componentType,property)](#M-Bb-Accessors-PropertyAccessor-#ctor-System-Type,System-Reflection-PropertyInfo,Bb-Accessors-MemberStrategy- 'Bb.Accessors.PropertyAccessor.#ctor(System.Type,System.Reflection.PropertyInfo,Bb.Accessors.MemberStrategy)')
- [PropertyBinder\`2](#T-Bb-Binders-PropertyBinder`2 'Bb.Binders.PropertyBinder`2')
  - [#ctor()](#M-Bb-Binders-PropertyBinder`2-#ctor 'Bb.Binders.PropertyBinder`2.#ctor')
  - [Bind\`\`1(expression,action)](#M-Bb-Binders-PropertyBinder`2-Bind``1-System-Linq-Expressions-Expression{System-Func{`0,``0}},System-Action{`1,``0}- 'Bb.Binders.PropertyBinder`2.Bind``1(System.Linq.Expressions.Expression{System.Func{`0,``0}},System.Action{`1,``0})')
  - [Observe(source,target)](#M-Bb-Binders-PropertyBinder`2-Observe-`0,`1- 'Bb.Binders.PropertyBinder`2.Observe(`0,`1)')
- [ReflexionHelper](#T-Bb-Converters-ReflexionHelper 'Bb.Converters.ReflexionHelper')
  - [GetMethodList(self)](#M-Bb-Converters-ReflexionHelper-GetMethodList-System-Type- 'Bb.Converters.ReflexionHelper.GetMethodList(System.Type)')
  - [GetMethods(self,filter)](#M-Bb-Converters-ReflexionHelper-GetMethods-System-Type,System-Func{System-Reflection-MethodInfo,System-Boolean}- 'Bb.Converters.ReflexionHelper.GetMethods(System.Type,System.Func{System.Reflection.MethodInfo,System.Boolean})')
- [ValidationHelper](#T-Bb-Accessors-ValidationHelper 'Bb.Accessors.ValidationHelper')
  - [Validate(dob,member,attributes)](#M-Bb-Accessors-ValidationHelper-Validate-System-Object,System-Reflection-MemberInfo,System-Collections-Generic-IEnumerable{System-ComponentModel-DataAnnotations-ValidationAttribute}- 'Bb.Accessors.ValidationHelper.Validate(System.Object,System.Reflection.MemberInfo,System.Collections.Generic.IEnumerable{System.ComponentModel.DataAnnotations.ValidationAttribute})')

<a name='T-Bb-Accessors-AccessorExtensions'></a>
## AccessorExtensions `type`

##### Namespace

Bb.Accessors

##### Summary

Extension methods for [AccessorItem](#T-Bb-Accessors-AccessorItem 'Bb.Accessors.AccessorItem')

<a name='M-Bb-Accessors-AccessorExtensions-GetAccessors-System-Type,Bb-Accessors-MemberStrategy,System-Func{System-Type,System-Boolean},System-Func{System-Reflection-MemberInfo,System-Boolean}-'></a>
### GetAccessors(type,strategy,filter,memberFilter) `method`

##### Summary

Returns a [AccessorList](#T-Bb-Accessors-AccessorList 'Bb.Accessors.AccessorList') for the specified type.

##### Returns

[AccessorList](#T-Bb-Accessors-AccessorList 'Bb.Accessors.AccessorList') with member accessors

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | type to evaluate |
| strategy | [Bb.Accessors.MemberStrategy](#T-Bb-Accessors-MemberStrategy 'Bb.Accessors.MemberStrategy') |  |
| filter | [System.Func{System.Type,System.Boolean}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Type,System.Boolean}') | filter to select declaring types |
| memberFilter | [System.Func{System.Reflection.MemberInfo,System.Boolean}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Reflection.MemberInfo,System.Boolean}') | filter to select members |

<a name='M-Bb-Accessors-AccessorExtensions-GetAccessors-System-Type,System-Func{System-Type,System-Boolean},System-Func{System-Reflection-MemberInfo,System-Boolean}-'></a>
### GetAccessors(type,filter,memberFilter) `method`

##### Summary

Returns a [AccessorList](#T-Bb-Accessors-AccessorList 'Bb.Accessors.AccessorList') for the specified type.

##### Returns

[AccessorList](#T-Bb-Accessors-AccessorList 'Bb.Accessors.AccessorList') with member accessors

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | type to evaluate |
| filter | [System.Func{System.Type,System.Boolean}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Type,System.Boolean}') | filter to select declaring types |
| memberFilter | [System.Func{System.Reflection.MemberInfo,System.Boolean}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Reflection.MemberInfo,System.Boolean}') | filter to select members |

<a name='M-Bb-Accessors-AccessorExtensions-ToList-System-ComponentModel-AttributeCollection-'></a>
### ToList(attributes) `method`

##### Summary

convert [AttributeCollection](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ComponentModel.AttributeCollection 'System.ComponentModel.AttributeCollection') to list of attributes

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| attributes | [System.ComponentModel.AttributeCollection](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ComponentModel.AttributeCollection 'System.ComponentModel.AttributeCollection') |  |

<a name='T-Bb-Accessors-AccessorItem'></a>
## AccessorItem `type`

##### Namespace

Bb.Accessors

##### Summary

Accessor base

<a name='M-Bb-Accessors-AccessorItem-#ctor-System-Type,Bb-Accessors-MemberTypeEnum,Bb-Accessors-MemberStrategy-'></a>
### #ctor(memberTypeEnum) `constructor`

##### Summary

Initializes a new instance of the [AccessorItem](#T-Bb-Accessors-AccessorItem 'Bb.Accessors.AccessorItem') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| memberTypeEnum | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | The member type enum. |

<a name='F-Bb-Accessors-AccessorItem-_lock'></a>
### _lock `constants`

##### Summary

The _lock

<a name='F-Bb-Accessors-AccessorItem-_strategyPropertiesAccessors'></a>
### _strategyPropertiesAccessors `constants`

##### Summary

The _accessors

<a name='P-Bb-Accessors-AccessorItem-CanRead'></a>
### CanRead `property`

##### Summary

Gets a value indicating whether [can read].

<a name='P-Bb-Accessors-AccessorItem-CanWrite'></a>
### CanWrite `property`

##### Summary

Gets a value indicating whether [can write].

<a name='P-Bb-Accessors-AccessorItem-Category'></a>
### Category `property`

##### Summary

Gets the category.

<a name='P-Bb-Accessors-AccessorItem-ComponentType'></a>
### ComponentType `property`

##### Summary

Original type

<a name='P-Bb-Accessors-AccessorItem-DeclaringType'></a>
### DeclaringType `property`

##### Summary

Gets or sets the type of the declaring.

<a name='P-Bb-Accessors-AccessorItem-DefaultValue'></a>
### DefaultValue `property`

##### Summary

Gets the default value.

<a name='P-Bb-Accessors-AccessorItem-DisplayDescription'></a>
### DisplayDescription `property`

##### Summary

Displays the description.

##### Returns



<a name='P-Bb-Accessors-AccessorItem-DisplayName'></a>
### DisplayName `property`

##### Summary

Displays the name.

##### Returns



<a name='P-Bb-Accessors-AccessorItem-GetValue'></a>
### GetValue `property`

##### Summary

Gets or sets the get value method.

<a name='P-Bb-Accessors-AccessorItem-IsClonable'></a>
### IsClonable `property`

##### Summary

Gets a value indicating whether [is clonable].

<a name='P-Bb-Accessors-AccessorItem-IsStatic'></a>
### IsStatic `property`

##### Summary

Gets or sets a value indicating whether [is static].

<a name='P-Bb-Accessors-AccessorItem-Member'></a>
### Member `property`

##### Summary

Gets or sets the member.

<a name='P-Bb-Accessors-AccessorItem-Name'></a>
### Name `property`

##### Summary

Gets or sets the name.

<a name='P-Bb-Accessors-AccessorItem-Required'></a>
### Required `property`

##### Summary

Gets a value indicating whether this [IAccessorItem](#T-IAccessorItem 'IAccessorItem') is required.

<a name='P-Bb-Accessors-AccessorItem-SetValue'></a>
### SetValue `property`

##### Summary

Gets or sets the set value method.

<a name='P-Bb-Accessors-AccessorItem-Strategy'></a>
### Strategy `property`

##### Summary

Gets the strategy accessor.

<a name='P-Bb-Accessors-AccessorItem-Tag'></a>
### Tag `property`

##### Summary

Gets or sets the tag.

<a name='P-Bb-Accessors-AccessorItem-Type'></a>
### Type `property`

##### Summary

Gets or sets the type.

<a name='P-Bb-Accessors-AccessorItem-TypeEnum'></a>
### TypeEnum `property`

##### Summary

Gets or sets the type enum.

<a name='M-Bb-Accessors-AccessorItem-ContainsAttribute``1'></a>
### ContainsAttribute\`\`1() `method`

##### Summary

Determines whether this instance contains attribute.

##### Returns

true if the object contains one or more of the specified attribute

##### Parameters

This method has no parameters.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Attribute to search |

<a name='M-Bb-Accessors-AccessorItem-ContainsAttribute``1-System-Object-'></a>
### ContainsAttribute\`\`1(instance) `method`

##### Summary

Determines whether this instance contains attribute.

##### Returns

true if the object contains one or more of the specified attribute

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| instance | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | instance to evaluate |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Attribute to search |

<a name='M-Bb-Accessors-AccessorItem-ConvertBeforeSettingValue-System-Object,System-Object-'></a>
### ConvertBeforeSettingValue(instance,value) `method`

##### Summary

Convert value before setting it.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| instance | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') |  |
| value | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') |  |

<a name='M-Bb-Accessors-AccessorItem-GetAttributes'></a>
### GetAttributes() `method`

##### Summary

Gets the attribute's list.

##### Returns

the list of attribute

##### Parameters

This method has no parameters.

<a name='M-Bb-Accessors-AccessorItem-GetAttributes-System-Object-'></a>
### GetAttributes(instance) `method`

##### Summary

Gets the attribute's list.

##### Returns

the list of attribute

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| instance | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | resolve the list of the reflexion or from type descriptor |

<a name='M-Bb-Accessors-AccessorItem-GetAttributes``1'></a>
### GetAttributes\`\`1() `method`

##### Summary

Gets the attribute's list.

##### Returns

the list of attribute

##### Parameters

This method has no parameters.

<a name='M-Bb-Accessors-AccessorItem-GetAttributes``1-System-Object-'></a>
### GetAttributes\`\`1(instance) `method`

##### Summary

Gets the attribute's list.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| instance | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | instance to evaluate |

<a name='M-Bb-Accessors-AccessorItem-GetTypedValue``1-System-Object-'></a>
### GetTypedValue\`\`1(instance) `method`

##### Summary

Gets the typed value converted in specified type.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| instance | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The instance. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T1 | The type of the returned value. |

<a name='M-Bb-Accessors-AccessorItem-GetValidatedValue-System-Object,System-Collections-Generic-IEnumerable{System-ComponentModel-DataAnnotations-ValidationAttribute}-'></a>
### GetValidatedValue(instance,attributes) `method`

##### Summary

Gets the validated value.

##### Returns

the value has been evaluated

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| instance | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The instance. |
| attributes | [System.Collections.Generic.IEnumerable{System.ComponentModel.DataAnnotations.ValidationAttribute}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{System.ComponentModel.DataAnnotations.ValidationAttribute}') | The attributes. |

<a name='M-Bb-Accessors-AccessorItem-IfAttribute``1-``0@-'></a>
### IfAttribute\`\`1() `method`

##### Summary

Resolve the attribute

##### Returns

Return the list of attribute to search

##### Parameters

This method has no parameters.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Attribute to search |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.InvalidOperationException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.InvalidOperationException 'System.InvalidOperationException') | Multiple attributes found |

<a name='M-Bb-Accessors-AccessorItem-IfAttribute``1-System-Object,``0@-'></a>
### IfAttribute\`\`1(instance,attribute) `method`

##### Summary

Resolve the attribute

##### Returns

Return the attribute to search

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| instance | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | instance to evaluate |
| attribute | [\`\`0@](#T-``0@ '``0@') | The attribute to return. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Attribute to search |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.InvalidOperationException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.InvalidOperationException 'System.InvalidOperationException') | Multiple attributes found |

<a name='M-Bb-Accessors-AccessorItem-IfAttributes``1-System-Collections-Generic-List{``0}@-'></a>
### IfAttributes\`\`1(attributes) `method`

##### Summary

Gets the attribute's list.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| attributes | [System.Collections.Generic.List{\`\`0}@](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{``0}@') | The attribute list to return. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Attribute to search |

<a name='M-Bb-Accessors-AccessorItem-IfAttributes``1-System-Object,System-Collections-Generic-List{``0}@-'></a>
### IfAttributes\`\`1(instance,attributes) `method`

##### Summary

Resolve the attribute's list.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| instance | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | instance to evaluate |
| attributes | [System.Collections.Generic.List{\`\`0}@](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{``0}@') | The attribute list to return. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Attribute to search |

<a name='M-Bb-Accessors-AccessorItem-ResolveName-System-String-'></a>
### ResolveName(name) `method`

##### Summary

Resolve the name

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-Bb-Accessors-AccessorItem-ValidateMember-System-Object,System-Boolean,System-Collections-Generic-IEnumerable{System-ComponentModel-DataAnnotations-ValidationAttribute}-'></a>
### ValidateMember(instance,throwException,attributes) `method`

##### Summary

Validates the member.

##### Returns

Return the result of the evaluation

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| instance | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The model. |
| throwException | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | if set to `true` [throw exception]. |
| attributes | [System.Collections.Generic.IEnumerable{System.ComponentModel.DataAnnotations.ValidationAttribute}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{System.ComponentModel.DataAnnotations.ValidationAttribute}') | The validationAttributes list to evaluate. |

<a name='T-Bb-Accessors-AccessorList'></a>
## AccessorList `type`

##### Namespace

Bb.Accessors

##### Summary

list of Accessors

<a name='M-Bb-Accessors-AccessorList-#ctor'></a>
### #ctor() `constructor`

##### Summary

Initializes a new instance of the [AccessorList](#T-Bb-Accessors-AccessorList 'Bb.Accessors.AccessorList') class.

##### Parameters

This constructor has no parameters.

<a name='M-Bb-Accessors-AccessorList-#ctor-System-Collections-Generic-IEnumerable{Bb-Accessors-AccessorItem}-'></a>
### #ctor(list) `constructor`

##### Summary

Initializes a new instance of the [AccessorList](#T-Bb-Accessors-AccessorList 'Bb.Accessors.AccessorList') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| list | [System.Collections.Generic.IEnumerable{Bb.Accessors.AccessorItem}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{Bb.Accessors.AccessorItem}') | The list. |

<a name='F-Bb-Accessors-AccessorList-_lock'></a>
### _lock `constants`

##### Summary

The _lock

<a name='P-Bb-Accessors-AccessorList-Count'></a>
### Count `property`

##### Summary

Gets the count of accessors.

<a name='P-Bb-Accessors-AccessorList-Item-System-String-'></a>
### Item `property`

##### Summary

Gets or sets the [IAccessorItem](#T-IAccessorItem 'IAccessorItem') with the specified name.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name. |

<a name='P-Bb-Accessors-AccessorList-Item-System-Reflection-MemberInfo-'></a>
### Item `property`

##### Summary

Gets or sets the [AccessorItem](#T-Bb-Accessors-AccessorItem 'Bb.Accessors.AccessorItem') with the specified member.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| member | [System.Reflection.MemberInfo](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.MemberInfo 'System.Reflection.MemberInfo') | The member. |

<a name='M-Bb-Accessors-AccessorList-Add-Bb-Accessors-AccessorItem-'></a>
### Add(propertyAccessor) `method`

##### Summary

Adds the specified property accessor.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| propertyAccessor | [Bb.Accessors.AccessorItem](#T-Bb-Accessors-AccessorItem 'Bb.Accessors.AccessorItem') | The property accessor. |

<a name='M-Bb-Accessors-AccessorList-ContainsKey-System-String-'></a>
### ContainsKey(name) `method`

##### Summary

Determines whether the specified name contains key.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name. |

<a name='M-Bb-Accessors-AccessorList-Get-System-String,System-Boolean-'></a>
### Get(memberName) `method`

##### Summary

Gets the specified member name.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| memberName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Name of the member. |

<a name='M-Bb-Accessors-AccessorList-GetEnumerator'></a>
### GetEnumerator() `method`

##### Summary

Returns an enumerator that iterates through the collection.

##### Returns

A [IEnumerator\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerator`1 'System.Collections.Generic.IEnumerator`1') that can be used to iterate through the collection.

##### Parameters

This method has no parameters.

<a name='M-Bb-Accessors-AccessorList-GetProperties-System-Type,System-Func{System-Type,System-Boolean}-'></a>
### GetProperties(componentType) `method`

##### Summary

Gets the properties.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| componentType | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | Type of the component. |

<a name='M-Bb-Accessors-AccessorList-Map-System-Object,System-Object-'></a>
### Map(source,target) `method`

##### Summary

Maps the specified source.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The source. |
| target | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The target. |

<a name='M-Bb-Accessors-AccessorList-Remove-Bb-Accessors-AccessorItem-'></a>
### Remove(propertyAccessor) `method`

##### Summary

Removes the specified property accessor.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| propertyAccessor | [Bb.Accessors.AccessorItem](#T-Bb-Accessors-AccessorItem 'Bb.Accessors.AccessorItem') | The property accessor. |

<a name='M-Bb-Accessors-AccessorList-Remove-System-String-'></a>
### Remove(name) `method`

##### Summary

Removes the specified name.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name. |

<a name='M-Bb-Accessors-AccessorList-System#Collections#IEnumerable#GetEnumerator'></a>
### System#Collections#IEnumerable#GetEnumerator() `method`

##### Summary

Returns an enumerator that iterates through a collection.

##### Returns

An [IEnumerator](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.IEnumerator 'System.Collections.IEnumerator') object that can be used to iterate through the collection.

##### Parameters

This method has no parameters.

<a name='M-Bb-Accessors-AccessorList-TryGetValue-System-String,Bb-Accessors-AccessorItem@-'></a>
### TryGetValue(name,member) `method`

##### Summary

Tries the get value.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name. |
| member | [Bb.Accessors.AccessorItem@](#T-Bb-Accessors-AccessorItem@ 'Bb.Accessors.AccessorItem@') | The member. |

<a name='M-Bb-Accessors-AccessorList-Validate-System-Object-'></a>
### Validate(instance) `method`

##### Summary

Validates the specified instance.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| instance | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The instance. |

<a name='M-Bb-Accessors-AccessorList-ValidateMember-System-Object,System-Reflection-MemberInfo,System-Collections-Generic-IEnumerable{System-ComponentModel-DataAnnotations-ValidationAttribute}-'></a>
### ValidateMember(value,member,attributes) `method`

##### Summary

Validates the specified dob.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The value to validate. |
| member | [System.Reflection.MemberInfo](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.MemberInfo 'System.Reflection.MemberInfo') | The member. |
| attributes | [System.Collections.Generic.IEnumerable{System.ComponentModel.DataAnnotations.ValidationAttribute}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{System.ComponentModel.DataAnnotations.ValidationAttribute}') | The attributes. |

<a name='T-Bb-Converters-ConnexionReaderExtension'></a>
## ConnexionReaderExtension `type`

##### Namespace

Bb.Converters

<a name='M-Bb-Converters-ConnexionReaderExtension-GetKeyValues-System-String-'></a>
### GetKeyValues(payload) `method`

##### Summary

Retrieves the key-value pairs from the given payload.

##### Returns

A dictionary containing the key-value pairs.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| payload | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The payload string. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown when the payload is null. |

##### Remarks

This method parses the payload string and extracts the key-value pairs. The payload string should be in a specific format where each key-value pair is separated by a delimiter.
The method uses the DbConnectionOptions class to parse the payload string and retrieve the key-value pairs.

<a name='T-Bb-Converters-ConverterContext'></a>
## ConverterContext `type`

##### Namespace

Bb.Converters

<a name='M-Bb-Converters-ConverterContext-#ctor-System-Globalization-CultureInfo-'></a>
### #ctor(cultureInfo) `constructor`

##### Summary

initialize a new instance of [ConverterContext](#T-Bb-Converters-ConverterContext 'Bb.Converters.ConverterContext')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| cultureInfo | [System.Globalization.CultureInfo](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Globalization.CultureInfo 'System.Globalization.CultureInfo') |  |

<a name='M-Bb-Converters-ConverterContext-#ctor'></a>
### #ctor() `constructor`

##### Summary

initialize a new instance of [ConverterContext](#T-Bb-Converters-ConverterContext 'Bb.Converters.ConverterContext')

##### Parameters

This constructor has no parameters.

<a name='M-Bb-Converters-ConverterContext-#ctor-System-Globalization-CultureInfo,System-Text-Encoding-'></a>
### #ctor(cultureInfo,encoding) `constructor`

##### Summary

initialize a new instance of [ConverterContext](#T-Bb-Converters-ConverterContext 'Bb.Converters.ConverterContext')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| cultureInfo | [System.Globalization.CultureInfo](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Globalization.CultureInfo 'System.Globalization.CultureInfo') |  |
| encoding | [System.Text.Encoding](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Text.Encoding 'System.Text.Encoding') |  |

<a name='P-Bb-Converters-ConverterContext-Culture'></a>
### Culture `property`

##### Summary

Culture used by default if the parameter is not specified

<a name='P-Bb-Converters-ConverterContext-DefaultCultureInfo'></a>
### DefaultCultureInfo `property`

##### Summary

Culture used by default if the parameter is not specified

<a name='P-Bb-Converters-ConverterContext-Encoding'></a>
### Encoding `property`

##### Summary

Encoding used by default if the parameter is not specified

<a name='T-Bb-Converters-ConverterHelper'></a>
## ConverterHelper `type`

##### Namespace

Bb.Converters

##### Summary

My Converter

<a name='M-Bb-Converters-ConverterHelper-#cctor'></a>
### #cctor() `method`

##### Summary

Constructor

##### Parameters

This method has no parameters.

<a name='M-Bb-Converters-ConverterHelper-AppendConverter-System-Delegate,System-Boolean-'></a>
### AppendConverter(method,replaceExisting) `method`

##### Summary

Append new method to register

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| method | [System.Delegate](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Delegate 'System.Delegate') |  |
| replaceExisting | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') |  |

<a name='M-Bb-Converters-ConverterHelper-AppendConverters-System-Type,System-Nullable{System-Boolean},System-Reflection-BindingFlags,System-Func{System-Reflection-MethodInfo,System-Boolean}-'></a>
### AppendConverters(type,replaceExisting,bindings) `method`

##### Summary

/// Add methods in the list of method to be used for conversion

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | type where the method can be found |
| replaceExisting | [System.Nullable{System.Boolean}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Boolean}') | if true, replace existing methods |
| bindings | [System.Reflection.BindingFlags](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.BindingFlags 'System.Reflection.BindingFlags') |  |

<a name='M-Bb-Converters-ConverterHelper-AppendConverters-System-Nullable{System-Boolean},System-Reflection-MethodInfo[]-'></a>
### AppendConverters(replaceExisting,ms) `method`

##### Summary

Add methods to the list of methods to be used for conversion

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| replaceExisting | [System.Nullable{System.Boolean}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Boolean}') | if true, replace existing methods |
| ms | [System.Reflection.MethodInfo[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.MethodInfo[] 'System.Reflection.MethodInfo[]') |  |

<a name='M-Bb-Converters-ConverterHelper-AppendConverters-System-Reflection-ConstructorInfo[]-'></a>
### AppendConverters(ms) `method`

##### Summary

Add methods to the list of methods to be used for conversion

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| ms | [System.Reflection.ConstructorInfo[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.ConstructorInfo[] 'System.Reflection.ConstructorInfo[]') |  |

<a name='M-Bb-Converters-ConverterHelper-ConvertTo-System-Object,System-Type,Bb-Converters-ConverterContext-'></a>
### ConvertTo(self,targetType,context) `method`

##### Summary

Converts a value to the specified target type.

##### Returns

The converted value.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The initial value to convert. Must not be null. |
| targetType | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | The target type to convert to. Must not be null. |
| context | [Bb.Converters.ConverterContext](#T-Bb-Converters-ConverterContext 'Bb.Converters.ConverterContext') | The conversion context. Can be null. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.InvalidOperationException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.InvalidOperationException 'System.InvalidOperationException') | Thrown if no conversion function is available for the specified types. |

##### Remarks

This method uses a conversion function specific to the source and target types.

<a name='M-Bb-Converters-ConverterHelper-ConvertTo-System-Object,System-Type-'></a>
### ConvertTo(self,targetType) `method`

##### Summary

Converts a value to the specified target type.

##### Returns

The converted value.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The initial value to convert. Must not be null. |
| targetType | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | The target type to convert to. Must not be null. |

##### Example

```C#
object result = "123".ConvertTo(typeof(int));
Console.WriteLine(result); // Output: 123
```

##### Remarks

This method uses the default conversion context.

<a name='M-Bb-Converters-ConverterHelper-ConvertTo-System-Object,System-Type,System-Globalization-CultureInfo-'></a>
### ConvertTo(self,targetType,culture) `method`

##### Summary

Convert a value to specified target type

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | initial value to convert |
| targetType | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | Target type |
| culture | [System.Globalization.CultureInfo](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Globalization.CultureInfo 'System.Globalization.CultureInfo') | culture for help conversion |

<a name='M-Bb-Converters-ConverterHelper-ConvertTo-System-Object,System-Type,System-Text-Encoding-'></a>
### ConvertTo(self,targetType,encoding) `method`

##### Summary

Convert a value to specified target type

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | initial value to convert |
| targetType | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | Target type |
| encoding | [System.Text.Encoding](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Text.Encoding 'System.Text.Encoding') | text encoding for help conversion |

<a name='M-Bb-Converters-ConverterHelper-ConvertTo-System-Object,System-Type,System-Globalization-CultureInfo,System-Text-Encoding-'></a>
### ConvertTo(self,culture,targetType,encoding) `method`

##### Summary

Convert a value to specified target type

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | initial value to convert |
| culture | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | culture for help conversion |
| targetType | [System.Globalization.CultureInfo](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Globalization.CultureInfo 'System.Globalization.CultureInfo') | Target type |
| encoding | [System.Text.Encoding](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Text.Encoding 'System.Text.Encoding') | text encoding for help conversion |

<a name='M-Bb-Converters-ConverterHelper-ConvertTo``1-System-Object-'></a>
### ConvertTo\`\`1(self) `method`

##### Summary

Converts a value to the specified target type.

##### Returns

The converted value.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The initial value to convert. Must not be null. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The target type to convert to. |

##### Example

```C#
int result = "123".ConvertTo&lt;int&gt;();
Console.WriteLine(result); // Output: 123
```

##### Remarks

This method uses the default conversion context.

<a name='M-Bb-Converters-ConverterHelper-ConvertTo``1-System-Object,System-Globalization-CultureInfo-'></a>
### ConvertTo\`\`1(self,culture) `method`

##### Summary

Converts a value to the specified target type using a specific culture.

##### Returns

The converted value.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The initial value to convert. Must not be null. |
| culture | [System.Globalization.CultureInfo](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Globalization.CultureInfo 'System.Globalization.CultureInfo') | The culture to use for the conversion. Must not be null. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The target type to convert to. |

##### Example

```C#
double result = "123.45".ConvertTo&lt;double&gt;(CultureInfo.InvariantCulture);
Console.WriteLine(result); // Output: 123.45
```

##### Remarks

This method allows specifying a culture to assist in the conversion process.

<a name='M-Bb-Converters-ConverterHelper-ConvertTo``1-System-Object,System-Text-Encoding-'></a>
### ConvertTo\`\`1(self,encoding) `method`

##### Summary

Converts a value to the specified target type using a specific text encoding.

##### Returns

The converted value.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The initial value to convert. Must not be null. |
| encoding | [System.Text.Encoding](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Text.Encoding 'System.Text.Encoding') | The text encoding to use for the conversion. Must not be null. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The target type to convert to. |

##### Example

```C#
string result = "Hello".ConvertTo&lt;string&gt;(Encoding.UTF8);
Console.WriteLine(result); // Output: Hello
```

##### Remarks

This method allows specifying a text encoding to assist in the conversion process.

<a name='M-Bb-Converters-ConverterHelper-ConvertTo``1-System-Object,System-Globalization-CultureInfo,System-Text-Encoding-'></a>
### ConvertTo\`\`1(self,culture,encoding) `method`

##### Summary

Converts a value to the specified target type using a specific culture and text encoding.

##### Returns

The converted value.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The initial value to convert. Must not be null. |
| culture | [System.Globalization.CultureInfo](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Globalization.CultureInfo 'System.Globalization.CultureInfo') | The culture to use for the conversion. Must not be null. |
| encoding | [System.Text.Encoding](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Text.Encoding 'System.Text.Encoding') | The text encoding to use for the conversion. Must not be null. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The target type to convert to. |

##### Example

```C#
string result = "123".ConvertTo&lt;string&gt;(CultureInfo.InvariantCulture, Encoding.UTF8);
Console.WriteLine(result); // Output: 123
```

##### Remarks

This method allows specifying both a culture and a text encoding to assist in the conversion process.

<a name='M-Bb-Converters-ConverterHelper-GetFunctionForConvert-System-Type,System-Type-'></a>
### GetFunctionForConvert(sourceType,targetType) `method`

##### Summary

Get the function to convert sourceType to targetType

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sourceType | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | Source type |
| targetType | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | Target type |

<a name='M-Bb-Converters-ConverterHelper-GetMethodToConvert-System-Type,System-Type-'></a>
### GetMethodToConvert(sourceType,targetType) `method`

##### Summary

Get the method to convert sourceType to targetType

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sourceType | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | Source type |
| targetType | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | Target type |

<a name='M-Bb-Converters-ConverterHelper-Methods-System-Predicate{Bb-Converters-MethodTypeConverter}-'></a>
### Methods(filter) `method`

##### Summary

Return all source types that can be converted to targetType

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| filter | [System.Predicate{Bb.Converters.MethodTypeConverter}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Predicate 'System.Predicate{Bb.Converters.MethodTypeConverter}') | filter for bypass items |

<a name='M-Bb-Converters-ConverterHelper-Register-Bb-Converters-MethodConverter-'></a>
### Register(newMethod) `method`

##### Summary

Register a new method to convert sourceType to targetType

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| newMethod | [Bb.Converters.MethodConverter](#T-Bb-Converters-MethodConverter 'Bb.Converters.MethodConverter') |  |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') | Method not allowed if the Property ToAdd is false |

##### Remarks

If a method already existing in the referential and the property ReplaceExisting is false, the method is not append

<a name='M-Bb-Converters-ConverterHelper-Reset-System-Type-'></a>
### Reset(type) `method`

##### Summary

Remove specified type

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | specified type to remove |

<a name='M-Bb-Converters-ConverterHelper-Serialize-System-Object-'></a>
### Serialize(value) `method`

##### Summary

Serializes the specified value in string.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The value. |

<a name='M-Bb-Converters-ConverterHelper-ToBoolean-System-String-'></a>
### ToBoolean(self) `method`

##### Summary

Convert a string to boolean

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-Bb-Converters-ConverterHelper-ToBoolean-System-Int32-'></a>
### ToBoolean(self) `method`

##### Summary

Convert a string to boolean

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') |  |

<a name='M-Bb-Converters-ConverterHelper-ToByte-System-Char[]-'></a>
### ToByte(value) `method`

##### Summary

Convert a string to byte

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Char[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Char[] 'System.Char[]') |  |

<a name='M-Bb-Converters-ConverterHelper-ToByte-System-Byte[]-'></a>
### ToByte(value) `method`

##### Summary

Convert a string to byte

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') |  |

<a name='M-Bb-Converters-ConverterHelper-ToByte-System-Single-'></a>
### ToByte(self) `method`

##### Summary

Convert a string to byte

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [System.Single](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Single 'System.Single') |  |

<a name='M-Bb-Converters-ConverterHelper-ToByteArray-System-String-'></a>
### ToByteArray(value) `method`

##### Summary

Convert a string to byte array

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-Bb-Converters-ConverterHelper-ToByteArray-System-Char[]-'></a>
### ToByteArray(value) `method`

##### Summary

Convert a string to byte array

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Char[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Char[] 'System.Char[]') |  |

<a name='M-Bb-Converters-ConverterHelper-ToByteArray-System-Char-'></a>
### ToByteArray(value) `method`

##### Summary

Convert a string to byte array

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Char](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Char 'System.Char') |  |

<a name='M-Bb-Converters-ConverterHelper-ToByteArray-System-Int32-'></a>
### ToByteArray(value) `method`

##### Summary

Convert a string to byte array

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') |  |

<a name='M-Bb-Converters-ConverterHelper-ToChar-System-Single-'></a>
### ToChar(self) `method`

##### Summary

Convert a string to char

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [System.Single](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Single 'System.Single') |  |

<a name='M-Bb-Converters-ConverterHelper-ToChar-System-Double-'></a>
### ToChar(self) `method`

##### Summary

Convert a string to char

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [System.Double](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Double 'System.Double') |  |

<a name='M-Bb-Converters-ConverterHelper-ToChar-System-Boolean-'></a>
### ToChar(self) `method`

##### Summary

Convert a string to char

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') |  |

<a name='M-Bb-Converters-ConverterHelper-ToChar-System-Decimal-'></a>
### ToChar(self) `method`

##### Summary

Convert a string to char

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [System.Decimal](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Decimal 'System.Decimal') |  |

<a name='M-Bb-Converters-ConverterHelper-ToChar-System-Int32-'></a>
### ToChar(self) `method`

##### Summary

Convert a string to char

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') |  |

<a name='M-Bb-Converters-ConverterHelper-ToChar-System-Byte[]-'></a>
### ToChar(value) `method`

##### Summary

Convert a string to char

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') |  |

<a name='M-Bb-Converters-ConverterHelper-ToChar-System-SByte[]-'></a>
### ToChar(value) `method`

##### Summary

Convert a string to char

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.SByte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.SByte[] 'System.SByte[]') |  |

<a name='M-Bb-Converters-ConverterHelper-ToChar-System-Char[]-'></a>
### ToChar(value) `method`

##### Summary

Convert a string to char

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Char[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Char[] 'System.Char[]') |  |

<a name='M-Bb-Converters-ConverterHelper-ToCharArray-System-Int32-'></a>
### ToCharArray(value) `method`

##### Summary

Convert a string to char array

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') |  |

<a name='M-Bb-Converters-ConverterHelper-ToCharArray-System-Guid-'></a>
### ToCharArray(value) `method`

##### Summary

Convert a string to char array

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Guid](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid 'System.Guid') |  |

<a name='M-Bb-Converters-ConverterHelper-ToCharArray-System-Byte[]-'></a>
### ToCharArray(value) `method`

##### Summary

Convert a string to char array

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') |  |

<a name='M-Bb-Converters-ConverterHelper-ToDateTime-System-DateTimeOffset-'></a>
### ToDateTime(value) `method`

##### Summary

Convert a DateTime to a DateTimeOffset

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.DateTimeOffset](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.DateTimeOffset 'System.DateTimeOffset') |  |

<a name='M-Bb-Converters-ConverterHelper-ToDateTimeOffser-System-TimeSpan-'></a>
### ToDateTimeOffser(value) `method`

##### Summary

Convert a string to DateTimeOffset

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.TimeSpan](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.TimeSpan 'System.TimeSpan') |  |

<a name='M-Bb-Converters-ConverterHelper-ToDateTimeOffset-System-String,System-Globalization-CultureInfo-'></a>
### ToDateTimeOffset(value,cultureInfo) `method`

##### Summary

Convert a string to DateTimeOffset

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| cultureInfo | [System.Globalization.CultureInfo](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Globalization.CultureInfo 'System.Globalization.CultureInfo') | [CultureInfo](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Globalization.CultureInfo 'System.Globalization.CultureInfo'). By default ConvertMore.CultureInfois used |

<a name='M-Bb-Converters-ConverterHelper-ToDateTimeOffset-System-DateTime-'></a>
### ToDateTimeOffset(value) `method`

##### Summary

Convert a DateTimeOffset to a DateTime

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.DateTime](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.DateTime 'System.DateTime') |  |

<a name='M-Bb-Converters-ConverterHelper-ToDateTimeOffset-System-SByte-'></a>
### ToDateTimeOffset(value) `method`

##### Summary

Convert a DateTimeOffset to a DateTime

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.SByte](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.SByte 'System.SByte') |  |

<a name='M-Bb-Converters-ConverterHelper-ToDateTimeOffset-System-Byte-'></a>
### ToDateTimeOffset(value) `method`

##### Summary

Convert a DateTimeOffset to a DateTime

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Byte](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte 'System.Byte') |  |

<a name='M-Bb-Converters-ConverterHelper-ToDateTimeOffset-System-Int16-'></a>
### ToDateTimeOffset(value) `method`

##### Summary

Convert a DateTimeOffset to a DateTime

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Int16](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int16 'System.Int16') |  |

<a name='M-Bb-Converters-ConverterHelper-ToDateTimeOffset-System-UInt16-'></a>
### ToDateTimeOffset(value) `method`

##### Summary

Convert a DateTimeOffset to a DateTime

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.UInt16](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.UInt16 'System.UInt16') |  |

<a name='M-Bb-Converters-ConverterHelper-ToDateTimeOffset-System-Int32-'></a>
### ToDateTimeOffset(value) `method`

##### Summary

Convert a DateTimeOffset to a DateTime

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') |  |

<a name='M-Bb-Converters-ConverterHelper-ToDateTimeOffset-System-UInt32-'></a>
### ToDateTimeOffset(value) `method`

##### Summary

Convert a DateTimeOffset to a DateTime

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.UInt32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.UInt32 'System.UInt32') |  |

<a name='M-Bb-Converters-ConverterHelper-ToDateTimeOffset-System-Int64-'></a>
### ToDateTimeOffset(value) `method`

##### Summary

Convert a DateTimeOffset to a DateTime

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Int64](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int64 'System.Int64') |  |

<a name='M-Bb-Converters-ConverterHelper-ToDateTimeOffset-System-UInt64-'></a>
### ToDateTimeOffset(value) `method`

##### Summary

Convert a DateTimeOffset to a DateTime

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.UInt64](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.UInt64 'System.UInt64') |  |

<a name='M-Bb-Converters-ConverterHelper-ToDateTimeOffset-System-Boolean-'></a>
### ToDateTimeOffset(value) `method`

##### Summary

Convert a DateTimeOffset to a DateTime

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') |  |

<a name='M-Bb-Converters-ConverterHelper-ToDateTimeOffset-System-Char-'></a>
### ToDateTimeOffset(value) `method`

##### Summary

Convert a DateTimeOffset to a DateTime

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Char](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Char 'System.Char') |  |

<a name='M-Bb-Converters-ConverterHelper-ToDateTimeOffset-System-Single-'></a>
### ToDateTimeOffset(value) `method`

##### Summary

Convert a DateTimeOffset to a DateTime

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Single](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Single 'System.Single') |  |

<a name='M-Bb-Converters-ConverterHelper-ToDateTimeOffset-System-Double-'></a>
### ToDateTimeOffset(value) `method`

##### Summary

Convert a DateTimeOffset to a DateTime

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Double](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Double 'System.Double') |  |

<a name='M-Bb-Converters-ConverterHelper-ToDateTimeOffset-System-Decimal-'></a>
### ToDateTimeOffset(value) `method`

##### Summary

Convert a DateTimeOffset to a DateTime

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Decimal](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Decimal 'System.Decimal') |  |

<a name='M-Bb-Converters-ConverterHelper-ToDecimal-System-Char-'></a>
### ToDecimal(value) `method`

##### Summary

Convert a string to Decimal

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Char](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Char 'System.Char') |  |

<a name='M-Bb-Converters-ConverterHelper-ToDictionaryObject-System-String-'></a>
### ToDictionaryObject(self) `method`

##### Summary

Convert a string to dictionary

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-Bb-Converters-ConverterHelper-ToDictionaryString-System-String-'></a>
### ToDictionaryString(self) `method`

##### Summary

Convert a string to dictionary

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-Bb-Converters-ConverterHelper-ToDouble-System-Char-'></a>
### ToDouble(value) `method`

##### Summary

Convert a string to Double

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Char](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Char 'System.Char') |  |

<a name='M-Bb-Converters-ConverterHelper-ToGuid-System-Char[]-'></a>
### ToGuid(value) `method`

##### Summary

Convert a string to Guid

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Char[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Char[] 'System.Char[]') |  |

<a name='M-Bb-Converters-ConverterHelper-ToInt16-System-Single-'></a>
### ToInt16(value) `method`

##### Summary

Convert a string to Int16

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Single](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Single 'System.Single') |  |

<a name='M-Bb-Converters-ConverterHelper-ToInt16-System-Double-'></a>
### ToInt16(value) `method`

##### Summary

Convert a string to Int16

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Double](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Double 'System.Double') |  |

<a name='M-Bb-Converters-ConverterHelper-ToInt16-System-Char-'></a>
### ToInt16(value) `method`

##### Summary

Convert a string to Int16

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Char](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Char 'System.Char') |  |

<a name='M-Bb-Converters-ConverterHelper-ToInt32-System-Single-'></a>
### ToInt32(value) `method`

##### Summary

Convert a string to Int32

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Single](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Single 'System.Single') |  |

<a name='M-Bb-Converters-ConverterHelper-ToInt32-System-Double-'></a>
### ToInt32(value) `method`

##### Summary

Convert a string to Int32

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Double](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Double 'System.Double') |  |

<a name='M-Bb-Converters-ConverterHelper-ToInt32-System-Char-'></a>
### ToInt32(value) `method`

##### Summary

Convert a string to Int32

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Char](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Char 'System.Char') |  |

<a name='M-Bb-Converters-ConverterHelper-ToInt64-System-Single-'></a>
### ToInt64(value) `method`

##### Summary

Convert a string to Int64

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Single](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Single 'System.Single') |  |

<a name='M-Bb-Converters-ConverterHelper-ToInt64-System-Double-'></a>
### ToInt64(value) `method`

##### Summary

Convert a string to Int64

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Double](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Double 'System.Double') |  |

<a name='M-Bb-Converters-ConverterHelper-ToInt64-System-Char-'></a>
### ToInt64(value) `method`

##### Summary

Convert a string to Int64

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Char](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Char 'System.Char') |  |

<a name='M-Bb-Converters-ConverterHelper-ToSByte-System-Char[]-'></a>
### ToSByte(value) `method`

##### Summary

Convert a string to sbyte

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Char[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Char[] 'System.Char[]') |  |

<a name='M-Bb-Converters-ConverterHelper-ToSByte-System-Byte[]-'></a>
### ToSByte(value) `method`

##### Summary

Convert a string to sbyte

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') |  |

<a name='M-Bb-Converters-ConverterHelper-ToSByte-System-SByte[]-'></a>
### ToSByte(value) `method`

##### Summary

Convert a string to sbyte

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.SByte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.SByte[] 'System.SByte[]') |  |

<a name='M-Bb-Converters-ConverterHelper-ToSingle-System-Char-'></a>
### ToSingle(value) `method`

##### Summary

Convert a string to Single

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Char](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Char 'System.Char') |  |

<a name='M-Bb-Converters-ConverterHelper-ToString-System-Guid-'></a>
### ToString(value) `method`

##### Summary

Convert a DateTime to string

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Guid](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid 'System.Guid') |  |

<a name='M-Bb-Converters-ConverterHelper-ToString-System-Char[]-'></a>
### ToString(self) `method`

##### Summary

Convert a DateTime to string

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [System.Char[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Char[] 'System.Char[]') |  |

<a name='M-Bb-Converters-ConverterHelper-ToString-System-Byte[]-'></a>
### ToString(self) `method`

##### Summary

Convert a DateTime to string

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') |  |

<a name='M-Bb-Converters-ConverterHelper-ToTimeSpan-System-DateTime-'></a>
### ToTimeSpan(value) `method`

##### Summary

Convert a DateTime to TimeSpan

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.DateTime](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.DateTime 'System.DateTime') |  |

<a name='M-Bb-Converters-ConverterHelper-ToTimeSpan-System-DateTimeOffset-'></a>
### ToTimeSpan(value) `method`

##### Summary

Convert a DateTimeOffset to TimeSpan

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.DateTimeOffset](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.DateTimeOffset 'System.DateTimeOffset') |  |

<a name='M-Bb-Converters-ConverterHelper-TryGetMethodToConvert-System-Type,System-Type,Bb-Converters-MethodConverter@-'></a>
### TryGetMethodToConvert(sourceType,targetType,method) `method`

##### Summary

Try to resolve the method to convert sourceType to targetType

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sourceType | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') |  |
| targetType | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') |  |
| method | [Bb.Converters.MethodConverter@](#T-Bb-Converters-MethodConverter@ 'Bb.Converters.MethodConverter@') |  |

<a name='M-Bb-Converters-ConverterHelper-Unserialize-System-String,System-Type-'></a>
### Unserialize(value,type) `method`

##### Summary

Deserializes the specified string value in the specified type.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The value. |
| type | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | The type. |

<a name='T-Bb-Converters-ConverterMoreNullable'></a>
## ConverterMoreNullable `type`

##### Namespace

Bb.Converters

<a name='M-Bb-Converters-ConverterMoreNullable-ToDateTime-System-DateTimeOffset-'></a>
### ToDateTime(value) `method`

##### Summary

Convert a DateTime to a DateTimeOffset

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.DateTimeOffset](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.DateTimeOffset 'System.DateTimeOffset') |  |

<a name='M-Bb-Converters-ConverterMoreNullable-ToDateTime-System-Nullable{System-DateTimeOffset}-'></a>
### ToDateTime(value) `method`

##### Summary

Convert a DateTime to a DateTimeOffset

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Nullable{System.DateTimeOffset}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.DateTimeOffset}') |  |

<a name='M-Bb-Converters-ConverterMoreNullable-ToDateTimeOffset-System-DateTime-'></a>
### ToDateTimeOffset(value) `method`

##### Summary

Convert a DateTime to DateTimeOffset

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.DateTime](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.DateTime 'System.DateTime') | DateTime |

<a name='M-Bb-Converters-ConverterMoreNullable-ToDateTimeOffset-System-String,System-Globalization-CultureInfo-'></a>
### ToDateTimeOffset(value,cultureInfo) `method`

##### Summary

Convert a DateTimeOffset to a DateTimeOffset

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| cultureInfo | [System.Globalization.CultureInfo](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Globalization.CultureInfo 'System.Globalization.CultureInfo') | [CultureInfo](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Globalization.CultureInfo 'System.Globalization.CultureInfo'). By default ConvertMore.CultureInfois used |

<a name='T-Bb-Converters-Converter`1'></a>
## Converter\`1 `type`

##### Namespace

Bb.Converters

##### Summary

Converter from T to string

 Set converts to string
 Get converts from string

<a name='P-Bb-Converters-Converter`1-Format'></a>
### Format `property`

##### Summary

Custom Format to be applied on bidirectional way.

<a name='T-Bb-Converters-Converter`2'></a>
## Converter\`2 `type`

##### Namespace

Bb.Converters

<a name='P-Bb-Converters-Converter`2-Culture'></a>
### Culture `property`

##### Summary

The culture info being used for decimal points, date and time format, etc.

<a name='T-Bb-DisposedEventHandler'></a>
## DisposedEventHandler `type`

##### Namespace

Bb

##### Summary

Represents the method that will handle the disposing of an object.
event raised when instance is disposed.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [T:Bb.DisposedEventHandler](#T-T-Bb-DisposedEventHandler 'T:Bb.DisposedEventHandler') | The source of the event. |

##### Remarks

This delegate represents the method that will be called when an object is being disposed.

<a name='T-Bb-Expressions-ExpressionHelper'></a>
## ExpressionHelper `type`

##### Namespace

Bb.Expressions

<a name='M-Bb-Expressions-ExpressionHelper-Add-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression-'></a>
### Add(left,right) `method`

##### Summary

Return add expression '+'

##### Returns

[BinaryExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.BinaryExpression 'System.Linq.Expressions.BinaryExpression')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| left | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | Left expression |
| right | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | right expression |

<a name='M-Bb-Expressions-ExpressionHelper-AddAssign-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression-'></a>
### AddAssign(left,right) `method`

##### Summary

Return add assign expression '+='

##### Returns

[BinaryExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.BinaryExpression 'System.Linq.Expressions.BinaryExpression')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| left | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | Left expression |
| right | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | right expression |

<a name='M-Bb-Expressions-ExpressionHelper-ArrayIndex-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression-'></a>
### ArrayIndex(self,index) `method`

##### Summary

return an expression array index

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | array |
| index | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | index of the array |

<a name='M-Bb-Expressions-ExpressionHelper-AsConstant-System-Object,System-Type-'></a>
### AsConstant(self,type) `method`

##### Summary

return a constant expression

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | object to convert to constant expression |
| type | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | target type of the expression |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.InvalidCastException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.InvalidCastException 'System.InvalidCastException') |  |

<a name='M-Bb-Expressions-ExpressionHelper-AssignFrom-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression-'></a>
### AssignFrom(left,right) `method`

##### Summary

create an expression that assign a value to a target

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| left | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | left expression that must be assigned |
| right | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | value expression to assign |

<a name='M-Bb-Expressions-ExpressionHelper-Call-System-Linq-Expressions-Expression,System-String,System-Linq-Expressions-Expression[]-'></a>
### Call(self,methodName,arguments) `method`

##### Summary

Create a call method expression

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | declaring instance expression |
| methodName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | method name |
| arguments | [System.Linq.Expressions.Expression[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression[] 'System.Linq.Expressions.Expression[]') | arguments of the method |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.MissingMemberException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.MissingMemberException 'System.MissingMemberException') |  |
| [Bb.Exceptions.DuplicatedArgumentNameException](#T-Bb-Exceptions-DuplicatedArgumentNameException 'Bb.Exceptions.DuplicatedArgumentNameException') |  |

<a name='M-Bb-Expressions-ExpressionHelper-Call-System-Linq-Expressions-Expression,System-Type,System-String,System-Linq-Expressions-Expression[]-'></a>
### Call(self,type,methodName,arguments) `method`

##### Summary

Create a call method expression

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | declaring instance expression |
| type | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | type that contains the method |
| methodName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | method name |
| arguments | [System.Linq.Expressions.Expression[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression[] 'System.Linq.Expressions.Expression[]') | arguments of the method |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.MissingMemberException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.MissingMemberException 'System.MissingMemberException') |  |
| [Bb.Exceptions.DuplicatedArgumentNameException](#T-Bb-Exceptions-DuplicatedArgumentNameException 'Bb.Exceptions.DuplicatedArgumentNameException') |  |

<a name='M-Bb-Expressions-ExpressionHelper-Call-System-Linq-Expressions-Expression,System-Reflection-MethodInfo,System-Linq-Expressions-Expression[]-'></a>
### Call(self,methodTarget,arguments) `method`

##### Summary

Create a call method expression

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | declaring instance expression |
| methodTarget | [System.Reflection.MethodInfo](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.MethodInfo 'System.Reflection.MethodInfo') | method member |
| arguments | [System.Linq.Expressions.Expression[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression[] 'System.Linq.Expressions.Expression[]') | arguments of the method |

<a name='M-Bb-Expressions-ExpressionHelper-Call-System-Reflection-MethodInfo,System-Linq-Expressions-Expression[]-'></a>
### Call(self,arguments) `method`

##### Summary

Create a call for static method

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [System.Reflection.MethodInfo](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.MethodInfo 'System.Reflection.MethodInfo') | method |
| arguments | [System.Linq.Expressions.Expression[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression[] 'System.Linq.Expressions.Expression[]') | argument of the method |

<a name='M-Bb-Expressions-ExpressionHelper-CallIsAssignableFrom-System-Type,System-Linq-Expressions-Expression-'></a>
### CallIsAssignableFrom(left,right) `method`

##### Summary

Evaluate the left expression can be assigned from right expression

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| left | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | left type expression |
| right | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | right type expression |

<a name='M-Bb-Expressions-ExpressionHelper-CallIsAssignableFrom-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression-'></a>
### CallIsAssignableFrom(left,right) `method`

##### Summary

Evaluate the left expression can be assigned from right expression

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| left | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | left type expression |
| right | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | right type expression |

<a name='M-Bb-Expressions-ExpressionHelper-CallIsAssignableTo-System-Type,System-Linq-Expressions-Expression-'></a>
### CallIsAssignableTo(left,right) `method`

##### Summary

Evaluate the left expression can be assigned to right expression

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| left | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | left type expression |
| right | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | right type expression |

<a name='M-Bb-Expressions-ExpressionHelper-CallIsAssignableTo-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression-'></a>
### CallIsAssignableTo(left,right) `method`

##### Summary

Evaluate the left expression can be assigned to right expression

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| left | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | left type expression |
| right | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | right type expression |

<a name='M-Bb-Expressions-ExpressionHelper-CallStatic-System-Reflection-MethodInfo,System-Linq-Expressions-Expression[]-'></a>
### CallStatic(self,arguments) `method`

##### Summary

Make a call to a static method

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [System.Reflection.MethodInfo](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.MethodInfo 'System.Reflection.MethodInfo') | method member info |
| arguments | [System.Linq.Expressions.Expression[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression[] 'System.Linq.Expressions.Expression[]') | argument of the call expression |

<a name='M-Bb-Expressions-ExpressionHelper-CanBeConverted-System-Type,System-Type-'></a>
### CanBeConverted(targetType,sourceType) `method`

##### Summary

evaluate if the types can be converted.
0 if the types are the same
1 if the source type can be converted in target type
2 if a method for convert the source type in target type exists

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| targetType | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | target type |
| sourceType | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | source type |

<a name='M-Bb-Expressions-ExpressionHelper-Coalesce-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression-'></a>
### Coalesce(left,right) `method`

##### Summary

return Coalesce expression '??'

##### Returns

[BinaryExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.BinaryExpression 'System.Linq.Expressions.BinaryExpression')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| left | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | Left expression |
| right | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | right expression |

<a name='M-Bb-Expressions-ExpressionHelper-ConvertIfDifferent-System-Linq-Expressions-Expression,System-Type,System-Linq-Expressions-ParameterExpression-'></a>
### ConvertIfDifferent(self,targetType) `method`

##### Summary

return an expression of conversion if target type are different

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | source expression to convert |
| targetType | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | target type |

<a name='M-Bb-Expressions-ExpressionHelper-CreateObject-System-Type,System-Linq-Expressions-Expression[]-'></a>
### CreateObject(type,args) `method`

##### Summary

return a new object expression

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | type of the array |
| args | [System.Linq.Expressions.Expression[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression[] 'System.Linq.Expressions.Expression[]') |  |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.MissingMethodException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.MissingMethodException 'System.MissingMethodException') |  |

<a name='M-Bb-Expressions-ExpressionHelper-CreateObject-System-Reflection-ConstructorInfo,System-Linq-Expressions-Expression[]-'></a>
### CreateObject(ctor,args) `method`

##### Summary

return a creation of object expression

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| ctor | [System.Reflection.ConstructorInfo](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.ConstructorInfo 'System.Reflection.ConstructorInfo') |  |
| args | [System.Linq.Expressions.Expression[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression[] 'System.Linq.Expressions.Expression[]') |  |

<a name='M-Bb-Expressions-ExpressionHelper-Decrement-System-Linq-Expressions-Expression-'></a>
### Decrement(left) `method`

##### Summary

return a unary expression that decrement the left expression

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| left | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | left expression |

<a name='M-Bb-Expressions-ExpressionHelper-DefaultValue-System-Type-'></a>
### DefaultValue(self) `method`

##### Summary

return a default expression

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | target type |

<a name='M-Bb-Expressions-ExpressionHelper-Divide-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression-'></a>
### Divide(left,right) `method`

##### Summary

return Divide expression '/'

##### Returns

[BinaryExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.BinaryExpression 'System.Linq.Expressions.BinaryExpression')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| left | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | Left expression |
| right | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | right expression |

<a name='M-Bb-Expressions-ExpressionHelper-DivideAssign-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression-'></a>
### DivideAssign(left,right) `method`

##### Summary

return DivideAssign expression '/='

##### Returns

[BinaryExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.BinaryExpression 'System.Linq.Expressions.BinaryExpression')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| left | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | Left expression |
| right | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | right expression |

<a name='M-Bb-Expressions-ExpressionHelper-Equal-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression-'></a>
### Equal(left,right) `method`

##### Summary

return Equal expression '=='

##### Returns

[BinaryExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.BinaryExpression 'System.Linq.Expressions.BinaryExpression')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| left | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | Left expression |
| right | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | right expression |

<a name='M-Bb-Expressions-ExpressionHelper-ExclusiveOr-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression-'></a>
### ExclusiveOr(left,right) `method`

##### Summary

return ExclusiveOr expression '||'

##### Returns

[BinaryExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.BinaryExpression 'System.Linq.Expressions.BinaryExpression')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| left | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | Left expression |
| right | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | right expression |

<a name='M-Bb-Expressions-ExpressionHelper-ExclusiveOrAssign-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression-'></a>
### ExclusiveOrAssign(left,right) `method`

##### Summary

return ExclusiveOrAssign expression '||='

##### Returns

[BinaryExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.BinaryExpression 'System.Linq.Expressions.BinaryExpression')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| left | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | Left expression |
| right | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | right expression |

<a name='M-Bb-Expressions-ExpressionHelper-Field-System-Linq-Expressions-Expression,System-String-'></a>
### Field(self,fieldName) `method`

##### Summary

create a member expression from field

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | declaring type expression |
| fieldName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | property name |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.MissingMemberException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.MissingMemberException 'System.MissingMemberException') |  |

<a name='M-Bb-Expressions-ExpressionHelper-Field-System-Linq-Expressions-Expression,System-String,System-Reflection-BindingFlags-'></a>
### Field(self,fieldName,binding) `method`

##### Summary

create a member expression from property

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | declaring type expression |
| fieldName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | property name |
| binding | [System.Reflection.BindingFlags](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.BindingFlags 'System.Reflection.BindingFlags') | filter for resolve property |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.MissingMemberException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.MissingMemberException 'System.MissingMemberException') |  |

<a name='M-Bb-Expressions-ExpressionHelper-Field-System-Linq-Expressions-Expression,System-Reflection-FieldInfo-'></a>
### Field(self,field) `method`

##### Summary

create a member expression from property

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') |  |
| field | [System.Reflection.FieldInfo](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.FieldInfo 'System.Reflection.FieldInfo') | property |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.NullReferenceException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.NullReferenceException 'System.NullReferenceException') |  |

<a name='M-Bb-Expressions-ExpressionHelper-GetBestMethod-System-Linq-Expressions-Expression[],System-Collections-Generic-List{System-Reflection-MethodInfo}-'></a>
### GetBestMethod(arguments,methods) `method`

##### Summary

Return the best method that match withe parameters

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| arguments | [System.Linq.Expressions.Expression[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression[] 'System.Linq.Expressions.Expression[]') | expression to passes |
| methods | [System.Collections.Generic.List{System.Reflection.MethodInfo}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{System.Reflection.MethodInfo}') | methods to evaluate |

<a name='M-Bb-Expressions-ExpressionHelper-GetBestMethod-System-Type[],System-Collections-Generic-List{System-Reflection-MethodInfo}-'></a>
### GetBestMethod(types,methods) `method`

##### Summary

Return the best method that match withe parameters

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| types | [System.Type[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type[] 'System.Type[]') | type to match |
| methods | [System.Collections.Generic.List{System.Reflection.MethodInfo}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{System.Reflection.MethodInfo}') | methods to evaluate |

<a name='M-Bb-Expressions-ExpressionHelper-GetFieldName-System-Linq-Expressions-Expression-'></a>
### GetFieldName(expression) `method`

##### Summary

Return the field name of the expression

##### Returns

return the property name

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| expression | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | expression that contains the property member |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='M-Bb-Expressions-ExpressionHelper-GetPropertyName-System-Linq-Expressions-Expression-'></a>
### GetPropertyName(expression) `method`

##### Summary

Return the property name of the expression

##### Returns

return the property name

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| expression | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | expression that contains the property member |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='M-Bb-Expressions-ExpressionHelper-GreaterThan-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression-'></a>
### GreaterThan(left,right) `method`

##### Summary

return GreaterThan expression '>'

##### Returns

[BinaryExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.BinaryExpression 'System.Linq.Expressions.BinaryExpression')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| left | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | Left expression |
| right | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | right expression |

<a name='M-Bb-Expressions-ExpressionHelper-GreaterThanOrEqual-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression-'></a>
### GreaterThanOrEqual(left,right) `method`

##### Summary

return GreaterThanOrEqual expression '>='

##### Returns

[BinaryExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.BinaryExpression 'System.Linq.Expressions.BinaryExpression')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| left | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | Left expression |
| right | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | right expression |

<a name='M-Bb-Expressions-ExpressionHelper-Increment-System-Linq-Expressions-Expression-'></a>
### Increment(left) `method`

##### Summary

return a unary expression that increment the left expression

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| left | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | left expression |

<a name='M-Bb-Expressions-ExpressionHelper-IsFalse-System-Linq-Expressions-Expression-'></a>
### IsFalse(left) `method`

##### Summary

return a unary expression that evaluate if the left expression is false

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| left | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | left expression |

<a name='M-Bb-Expressions-ExpressionHelper-IsTrue-System-Linq-Expressions-Expression-'></a>
### IsTrue(left) `method`

##### Summary

return a unary expression that evaluate if the left expression is true

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| left | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | left expression |

<a name='M-Bb-Expressions-ExpressionHelper-Loop-System-Linq-Expressions-Expression-'></a>
### Loop(body) `method`

##### Summary

Create a loop with bloc

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| body | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') |  |

<a name='M-Bb-Expressions-ExpressionHelper-Modulo-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression-'></a>
### Modulo(left,right) `method`

##### Summary

return Modulo expression '%'

##### Returns

[BinaryExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.BinaryExpression 'System.Linq.Expressions.BinaryExpression')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| left | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | Left expression |
| right | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | right expression |

<a name='M-Bb-Expressions-ExpressionHelper-ModuloAssign-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression-'></a>
### ModuloAssign(left,right) `method`

##### Summary

return ModuloAssign expression '%='

##### Returns

[BinaryExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.BinaryExpression 'System.Linq.Expressions.BinaryExpression')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| left | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | Left expression |
| right | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | right expression |

<a name='M-Bb-Expressions-ExpressionHelper-Multiply-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression-'></a>
### Multiply(left,right) `method`

##### Summary

return Multiply expression '*'

##### Returns

[BinaryExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.BinaryExpression 'System.Linq.Expressions.BinaryExpression')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| left | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | Left expression |
| right | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | right expression |

<a name='M-Bb-Expressions-ExpressionHelper-MultiplyAssign-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression-'></a>
### MultiplyAssign(left,right) `method`

##### Summary

return MultiplyAssign expression '*='

##### Returns

[BinaryExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.BinaryExpression 'System.Linq.Expressions.BinaryExpression')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| left | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | Left expression |
| right | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | right expression |

<a name='M-Bb-Expressions-ExpressionHelper-Negate-System-Linq-Expressions-Expression-'></a>
### Negate(left) `method`

##### Summary

return a unary expression that negate the left expression

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| left | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | left expression |

<a name='M-Bb-Expressions-ExpressionHelper-NewArray-System-Type,System-Collections-Generic-IEnumerable{System-Linq-Expressions-Expression}-'></a>
### NewArray(self,expressions) `method`

##### Summary

return a new array expression

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') |  |
| expressions | [System.Collections.Generic.IEnumerable{System.Linq.Expressions.Expression}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{System.Linq.Expressions.Expression}') |  |

<a name='M-Bb-Expressions-ExpressionHelper-NewArray-System-Type,System-Linq-Expressions-Expression[]-'></a>
### NewArray(self,expressions) `method`

##### Summary

return a new array expression

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | type of the array |
| expressions | [System.Linq.Expressions.Expression[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression[] 'System.Linq.Expressions.Expression[]') |  |

<a name='M-Bb-Expressions-ExpressionHelper-Not-System-Linq-Expressions-Expression-'></a>
### Not(left) `method`

##### Summary

return a not unary expression that negate the left expression

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| left | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | left expression |

<a name='M-Bb-Expressions-ExpressionHelper-NotEqual-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression-'></a>
### NotEqual(left,right) `method`

##### Summary

return NotEqual expression '!='

##### Returns

[BinaryExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.BinaryExpression 'System.Linq.Expressions.BinaryExpression')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| left | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | Left expression |
| right | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | right expression |

<a name='M-Bb-Expressions-ExpressionHelper-Or-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression-'></a>
### Or(left,right) `method`

##### Summary

return Or expression '|'

##### Returns

[BinaryExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.BinaryExpression 'System.Linq.Expressions.BinaryExpression')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| left | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | Left expression |
| right | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | right expression |

<a name='M-Bb-Expressions-ExpressionHelper-OrAssign-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression-'></a>
### OrAssign(left,right) `method`

##### Summary

return OrAssign expression '|='

##### Returns

[BinaryExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.BinaryExpression 'System.Linq.Expressions.BinaryExpression')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| left | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | Left expression |
| right | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | right expression |

<a name='M-Bb-Expressions-ExpressionHelper-OrElse-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression-'></a>
### OrElse(left,right) `method`

##### Summary

return OrElse expression '||'

##### Returns

[BinaryExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.BinaryExpression 'System.Linq.Expressions.BinaryExpression')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| left | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | Left expression |
| right | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | right expression |

<a name='M-Bb-Expressions-ExpressionHelper-OrderMethods-System-Collections-Generic-List{System-Reflection-MethodInfo},System-Type-'></a>
### OrderMethods(methods,type) `method`

##### Summary

Order methods by declaring type

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| methods | [System.Collections.Generic.List{System.Reflection.MethodInfo}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{System.Reflection.MethodInfo}') | method to sort |
| type | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | first type |

<a name='M-Bb-Expressions-ExpressionHelper-PostDecrementAssign-System-Linq-Expressions-Expression-'></a>
### PostDecrementAssign(left) `method`

##### Summary

return a unary expression that post decrement the left expression

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| left | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | left expression |

<a name='M-Bb-Expressions-ExpressionHelper-PostIncrementAssign-System-Linq-Expressions-Expression-'></a>
### PostIncrementAssign(left) `method`

##### Summary

return a unary expression that post increment the left expression

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| left | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | left expression |

<a name='M-Bb-Expressions-ExpressionHelper-Power-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression-'></a>
### Power(left,right) `method`

##### Summary

return Power expression '^'

##### Returns

[BinaryExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.BinaryExpression 'System.Linq.Expressions.BinaryExpression')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| left | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | Left expression |
| right | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | right expression |

<a name='M-Bb-Expressions-ExpressionHelper-PowerAssign-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression-'></a>
### PowerAssign(left,right) `method`

##### Summary

return PowerAssign expression '^='

##### Returns

[BinaryExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.BinaryExpression 'System.Linq.Expressions.BinaryExpression')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| left | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | Left expression |
| right | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | right expression |

<a name='M-Bb-Expressions-ExpressionHelper-PreDecrementAssign-System-Linq-Expressions-Expression-'></a>
### PreDecrementAssign(left) `method`

##### Summary

return a unary expression that pre decrement the left expression

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| left | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | left expression |

<a name='M-Bb-Expressions-ExpressionHelper-PreIncrementAssign-System-Linq-Expressions-Expression-'></a>
### PreIncrementAssign(left) `method`

##### Summary

return a unary expression that pre increment the left expression

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| left | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | left expression |

<a name='M-Bb-Expressions-ExpressionHelper-Property-System-Linq-Expressions-Expression,System-String-'></a>
### Property(self,propertyName) `method`

##### Summary

create a member expression from property

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | declaring type expression |
| propertyName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | property name |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.MissingMemberException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.MissingMemberException 'System.MissingMemberException') |  |

<a name='M-Bb-Expressions-ExpressionHelper-Property-System-Linq-Expressions-Expression,System-String,System-Reflection-BindingFlags-'></a>
### Property(self,propertyName,binding) `method`

##### Summary

create a member expression from property

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') |  |
| propertyName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | property |
| binding | [System.Reflection.BindingFlags](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.BindingFlags 'System.Reflection.BindingFlags') | filter for resolve field |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.NullReferenceException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.NullReferenceException 'System.NullReferenceException') |  |

<a name='M-Bb-Expressions-ExpressionHelper-Property-System-Linq-Expressions-Expression,System-Reflection-PropertyInfo-'></a>
### Property(self,property) `method`

##### Summary

create a member expression from property

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') |  |
| property | [System.Reflection.PropertyInfo](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.PropertyInfo 'System.Reflection.PropertyInfo') | property |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.NullReferenceException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.NullReferenceException 'System.NullReferenceException') |  |

<a name='M-Bb-Expressions-ExpressionHelper-ResolveType-System-Linq-Expressions-Expression-'></a>
### ResolveType(self) `method`

##### Summary

Resolve the type of the expression

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') |  |

<a name='M-Bb-Expressions-ExpressionHelper-RightShift-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression-'></a>
### RightShift(left,right) `method`

##### Summary

return RightShift expression '>>'

##### Returns

[BinaryExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.BinaryExpression 'System.Linq.Expressions.BinaryExpression')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| left | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | Left expression |
| right | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | right expression |

<a name='M-Bb-Expressions-ExpressionHelper-RightShiftAssign-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression-'></a>
### RightShiftAssign(left,right) `method`

##### Summary

return RightShiftAssign expression '>>='

##### Returns

[BinaryExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.BinaryExpression 'System.Linq.Expressions.BinaryExpression')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| left | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | Left expression |
| right | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | right expression |

<a name='M-Bb-Expressions-ExpressionHelper-SortBestMethod-System-Linq-Expressions-Expression[],System-Collections-Generic-List{System-Reflection-MethodInfo}-'></a>
### SortBestMethod(arguments,methods) `method`

##### Summary

Sort the best method that match withe parameters

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| arguments | [System.Linq.Expressions.Expression[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression[] 'System.Linq.Expressions.Expression[]') | expression to passes |
| methods | [System.Collections.Generic.List{System.Reflection.MethodInfo}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{System.Reflection.MethodInfo}') | methods to evaluate |

<a name='M-Bb-Expressions-ExpressionHelper-SortBestMethod-System-Type[],System-Collections-Generic-List{System-Reflection-MethodInfo}-'></a>
### SortBestMethod(types,methods) `method`

##### Summary

Sort the best method that match withe parameters

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| types | [System.Type[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type[] 'System.Type[]') | type to match |
| methods | [System.Collections.Generic.List{System.Reflection.MethodInfo}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{System.Reflection.MethodInfo}') | methods to evaluate |

<a name='M-Bb-Expressions-ExpressionHelper-Subtract-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression-'></a>
### Subtract(left,right) `method`

##### Summary

return Subtract expression '-'

##### Returns

[BinaryExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.BinaryExpression 'System.Linq.Expressions.BinaryExpression')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| left | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | Left expression |
| right | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | right expression |

<a name='M-Bb-Expressions-ExpressionHelper-SubtractAssign-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression-'></a>
### SubtractAssign(left,right) `method`

##### Summary

return SubtractAssign expression '-='

##### Returns

[BinaryExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.BinaryExpression 'System.Linq.Expressions.BinaryExpression')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| left | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | Left expression |
| right | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | right expression |

<a name='M-Bb-Expressions-ExpressionHelper-Throw-System-Type,System-Linq-Expressions-Expression[]-'></a>
### Throw(type,args) `method`

##### Summary

Throw an exception

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | type of expression |
| args | [System.Linq.Expressions.Expression[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression[] 'System.Linq.Expressions.Expression[]') | argument of the constructor |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.InvalidCastException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.InvalidCastException 'System.InvalidCastException') |  |

<a name='M-Bb-Expressions-ExpressionHelper-TypeAs-System-Linq-Expressions-Expression,System-Type-'></a>
### TypeAs(left,type) `method`

##### Summary

return a unary expression that convert the left expression in the target type

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| left | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | left expression |
| type | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | type to convert |

<a name='M-Bb-Expressions-ExpressionHelper-TypeAsConstant-System-Type-'></a>
### TypeAsConstant(self) `method`

##### Summary

Return a constant expression with type

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') |  |

<a name='M-Bb-Expressions-ExpressionHelper-TypeEqual-System-Linq-Expressions-Expression,System-Type-'></a>
### TypeEqual(left,type) `method`

##### Summary

return a binary expression that compare the left and right expression

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| left | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | left expression |
| type | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | right expression |

<a name='M-Bb-Expressions-ExpressionHelper-TypeIs-System-Linq-Expressions-Expression,System-Type-'></a>
### TypeIs(left,type) `method`

##### Summary

Return an expression that evaluate if the left expression is of the type

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| left | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | Left expression |
| type | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') |  |

<a name='T-Bb-Expressions-ExpressionMemberVisitor'></a>
## ExpressionMemberVisitor `type`

##### Namespace

Bb.Expressions

<a name='M-Bb-Expressions-ExpressionMemberVisitor-GetPropertyName-System-Linq-Expressions-Expression-'></a>
### GetPropertyName(e) `method`

##### Summary

Return the property name of the expression

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| e | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') |  |

<a name='T-Bb-Accessors-FieldAccessor'></a>
## FieldAccessor `type`

##### Namespace

Bb.Accessors

##### Summary

Field Accessor

<a name='M-Bb-Accessors-FieldAccessor-#ctor-System-Type,System-Reflection-FieldInfo,Bb-Accessors-MemberStrategy-'></a>
### #ctor(componentType,field) `constructor`

##### Summary

Initializes a new instance of the [PropertyAccessor](#T-Bb-Accessors-PropertyAccessor 'Bb.Accessors.PropertyAccessor') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| componentType | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | Type of the component. |
| field | [System.Reflection.FieldInfo](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.FieldInfo 'System.Reflection.FieldInfo') | The property. |

<a name='T-Bb-IDisposed'></a>
## IDisposed `type`

##### Namespace

Bb

##### Summary

Represents an object that can be disposed.

<a name='T-Bb-ComponentModel-IUIComponent'></a>
## IUIComponent `type`

##### Namespace

Bb.ComponentModel

##### Summary

Represents a component that can be added to a container.

<a name='M-Bb-ComponentModel-IUIComponent-GetService-System-Type-'></a>
### GetService(type) `method`

##### Summary

Get asked service

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') |  |

<a name='T-Bb-ComponentModel-IUISite'></a>
## IUISite `type`

##### Namespace

Bb.ComponentModel

##### Summary

Represents a component that can be added to a container.

<a name='P-Bb-ComponentModel-IUISite-Parent'></a>
### Parent `property`

##### Summary

Gets the name of the parent component.

<a name='T-Bb-Binders-InstanceBinder`2'></a>
## InstanceBinder\`2 `type`

##### Namespace

Bb.Binders

<a name='M-Bb-Binders-InstanceBinder`2-#ctor-Bb-Binders-PropertyBinder{`0,`1}-'></a>
### #ctor(configuration) `constructor`

##### Summary

Create a new instance of [InstanceBinder\`2](#T-Bb-Binders-InstanceBinder`2 'Bb.Binders.InstanceBinder`2')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| configuration | [Bb.Binders.PropertyBinder{\`0,\`1}](#T-Bb-Binders-PropertyBinder{`0,`1} 'Bb.Binders.PropertyBinder{`0,`1}') |  |

<a name='M-Bb-Binders-InstanceBinder`2-Bind-`0,`1-'></a>
### Bind(source,target) `method`

##### Summary

Bind the source on the target instance

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [\`0](#T-`0 '`0') |  |
| target | [\`1](#T-`1 '`1') |  |

<a name='M-Bb-Binders-InstanceBinder`2-Dispose'></a>
### Dispose() `method`

##### Summary

instance make to dispose

##### Parameters

This method has no parameters.

<a name='T-Bb-Accessors-MemberStrategy'></a>
## MemberStrategy `type`

##### Namespace

Bb.Accessors

<a name='F-Bb-Accessors-MemberStrategy-ConvertIfDifferent'></a>
### ConvertIfDifferent `constants`

##### Summary

Convert the argument in the target type property if different.

<a name='F-Bb-Accessors-MemberStrategy-Direct'></a>
### Direct `constants`

##### Summary

direct copy of the value in the property

<a name='F-Bb-Accessors-MemberStrategy-Fields'></a>
### Fields `constants`

##### Summary

Append the fields in the accessor's list

<a name='F-Bb-Accessors-MemberStrategy-Instance'></a>
### Instance `constants`

##### Summary

Include instance members

<a name='F-Bb-Accessors-MemberStrategy-NotPublicFields'></a>
### NotPublicFields `constants`

##### Summary

Include not public fields

<a name='F-Bb-Accessors-MemberStrategy-Properties'></a>
### Properties `constants`

##### Summary

Append the properties in the accessor's list

<a name='F-Bb-Accessors-MemberStrategy-Static'></a>
### Static `constants`

##### Summary

Include static members

<a name='T-Bb-Accessors-MemberTypeEnum'></a>
## MemberTypeEnum `type`

##### Namespace

Bb.Accessors

##### Summary

/// member's type

<a name='F-Bb-Accessors-MemberTypeEnum-Field'></a>
### Field `constants`

##### Summary

The member is of type field

<a name='F-Bb-Accessors-MemberTypeEnum-Property'></a>
### Property `constants`

##### Summary

The member is of type property

<a name='T-Bb-Converters-MethodConverter'></a>
## MethodConverter `type`

##### Namespace

Bb.Converters

##### Summary

package data for conversion

<a name='M-Bb-Converters-MethodConverter-#ctor-System-Delegate-'></a>
### #ctor(delegate) `constructor`

##### Summary

Initializes a new instance of the [MethodConverter](#T-Bb-Converters-MethodConverter 'Bb.Converters.MethodConverter') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| delegate | [System.Delegate](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Delegate 'System.Delegate') | method to use for convert |

<a name='M-Bb-Converters-MethodConverter-#ctor-System-Reflection-ConstructorInfo-'></a>
### #ctor(method) `constructor`

##### Summary

Initializes a new instance of the [MethodConverter](#T-Bb-Converters-MethodConverter 'Bb.Converters.MethodConverter') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| method | [System.Reflection.ConstructorInfo](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.ConstructorInfo 'System.Reflection.ConstructorInfo') |  |

<a name='M-Bb-Converters-MethodConverter-#ctor-System-Reflection-MethodInfo-'></a>
### #ctor(method) `constructor`

##### Summary

Initializes a new instance of the [MethodConverter](#T-Bb-Converters-MethodConverter 'Bb.Converters.MethodConverter') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| method | [System.Reflection.MethodInfo](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.MethodInfo 'System.Reflection.MethodInfo') |  |

<a name='P-Bb-Converters-MethodConverter-Case'></a>
### Case `property`

##### Summary

Gets the case of the converter.

<a name='P-Bb-Converters-MethodConverter-IsGenericConverter'></a>
### IsGenericConverter `property`

##### Summary

Gets a value indicating whether this method is a generic converter.

<a name='P-Bb-Converters-MethodConverter-IsStatic'></a>
### IsStatic `property`

##### Summary

Gets a value indicating whether this method is static.

<a name='P-Bb-Converters-MethodConverter-Method'></a>
### Method `property`

##### Summary

Gets the method to use.

<a name='P-Bb-Converters-MethodConverter-Parameter0'></a>
### Parameter0 `property`

##### Summary

Parameter 0

<a name='P-Bb-Converters-MethodConverter-Parameter1'></a>
### Parameter1 `property`

##### Summary

Parameter 1

<a name='P-Bb-Converters-MethodConverter-ReplaceExistings'></a>
### ReplaceExistings `property`

##### Summary

If true, the converter will replace existing converters

<a name='P-Bb-Converters-MethodConverter-SourceType'></a>
### SourceType `property`

##### Summary

Managed type to convert

<a name='P-Bb-Converters-MethodConverter-TargetType'></a>
### TargetType `property`

##### Summary

Managed target type to convert.

<a name='P-Bb-Converters-MethodConverter-ToAdd'></a>
### ToAdd `property`

##### Summary

If true, the converter can be added to the list of converters

<a name='M-Bb-Converters-MethodConverter-Equals-System-Object-'></a>
### Equals(obj) `method`

##### Summary

Determines whether the specified object is equal to the current object.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| obj | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') |  |

<a name='M-Bb-Converters-MethodConverter-GetHashCode'></a>
### GetHashCode() `method`

##### Summary

Returns the hash code for this instance.

##### Returns



##### Parameters

This method has no parameters.

<a name='M-Bb-Converters-MethodConverter-ToString'></a>
### ToString() `method`

##### Summary

Returns a string that represents the current object.

##### Returns



##### Parameters

This method has no parameters.

<a name='M-Bb-Converters-MethodConverter-op_Implicit-System-Delegate-~Bb-Converters-MethodConverter'></a>
### op_Implicit(delegate) `method`

##### Summary

implicit conversion from [](#!-delegate 'delegate') to [MethodConverter](#T-Bb-Converters-MethodConverter 'Bb.Converters.MethodConverter')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| delegate | [System.Delegate)~Bb.Converters.MethodConverter](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Delegate)~Bb.Converters.MethodConverter 'System.Delegate)~Bb.Converters.MethodConverter') |  |

<a name='M-Bb-Converters-MethodConverter-op_Implicit-System-Reflection-MethodInfo-~Bb-Converters-MethodConverter'></a>
### op_Implicit(method) `method`

##### Summary

Implicit conversion from [MethodInfo](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.MethodInfo 'System.Reflection.MethodInfo') to [MethodConverter](#T-Bb-Converters-MethodConverter 'Bb.Converters.MethodConverter')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| method | [System.Reflection.MethodInfo)~Bb.Converters.MethodConverter](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.MethodInfo)~Bb.Converters.MethodConverter 'System.Reflection.MethodInfo)~Bb.Converters.MethodConverter') |  |

<a name='M-Bb-Converters-MethodConverter-op_Implicit-System-Reflection-ConstructorInfo-~Bb-Converters-MethodConverter'></a>
### op_Implicit(method) `method`

##### Summary

Implicit conversion from [ConstructorInfo](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.ConstructorInfo 'System.Reflection.ConstructorInfo') to [MethodConverter](#T-Bb-Converters-MethodConverter 'Bb.Converters.MethodConverter')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| method | [System.Reflection.ConstructorInfo)~Bb.Converters.MethodConverter](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.ConstructorInfo)~Bb.Converters.MethodConverter 'System.Reflection.ConstructorInfo)~Bb.Converters.MethodConverter') |  |

<a name='T-Bb-Converters-MethodTypeConverter'></a>
## MethodTypeConverter `type`

##### Namespace

Bb.Converters

##### Summary

Manage the conversion functions for a type

<a name='M-Bb-Converters-MethodTypeConverter-#ctor-System-Type-'></a>
### #ctor(type) `constructor`

##### Summary

create a new instance of [MethodTypeConverter](#T-Bb-Converters-MethodTypeConverter 'Bb.Converters.MethodTypeConverter')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | managed source type |

<a name='P-Bb-Converters-MethodTypeConverter-Item-System-Type-'></a>
### Item `property`

##### Summary

Get the list of conversion functions for the target type

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| key | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') |  |

<a name='P-Bb-Converters-MethodTypeConverter-SourceType'></a>
### SourceType `property`

##### Summary

Managed source type

<a name='M-Bb-Converters-MethodTypeConverter-Add-Bb-Converters-MethodConverter-'></a>
### Add(newMethod) `method`

##### Summary

Add a conversion function

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| newMethod | [Bb.Converters.MethodConverter](#T-Bb-Converters-MethodConverter 'Bb.Converters.MethodConverter') |  |

<a name='M-Bb-Converters-MethodTypeConverter-AddFunction-System-Type,System-Func{System-Object,Bb-Converters-ConverterContext,System-Object}-'></a>
### AddFunction(targetType,func) `method`

##### Summary

Add a conversion function

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| targetType | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') |  |
| func | [System.Func{System.Object,Bb.Converters.ConverterContext,System.Object}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Object,Bb.Converters.ConverterContext,System.Object}') |  |

<a name='M-Bb-Converters-MethodTypeConverter-Functions'></a>
### Functions() `method`

##### Summary

Return the list of generated conversion functions

##### Returns



##### Parameters

This method has no parameters.

<a name='M-Bb-Converters-MethodTypeConverter-TryGetFunction-System-Type,System-Func{System-Object,Bb-Converters-ConverterContext,System-Object}@-'></a>
### TryGetFunction(targetType,result) `method`

##### Summary

Try to get the conversion function for the target type

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| targetType | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') |  |
| result | [System.Func{System.Object,Bb.Converters.ConverterContext,System.Object}@](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Object,Bb.Converters.ConverterContext,System.Object}@') |  |

<a name='M-Bb-Converters-MethodTypeConverter-TryGetValue-System-Type,System-Collections-Generic-List{Bb-Converters-MethodConverter}@-'></a>
### TryGetValue(key,value) `method`

##### Summary

Try to get the list of conversion functions for the target type

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| key | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') |  |
| value | [System.Collections.Generic.List{Bb.Converters.MethodConverter}@](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{Bb.Converters.MethodConverter}@') |  |

<a name='T-Bb-Expressions-PrivatedIndex'></a>
## PrivatedIndex `type`

##### Namespace

Bb.Expressions

##### Summary

internal unique index generator

<a name='M-Bb-Expressions-PrivatedIndex-GetNewIndex'></a>
### GetNewIndex() `method`

##### Summary

return unique index.this method is thread safe.

##### Returns

unique index

##### Parameters

This method has no parameters.

<a name='T-Bb-Accessors-PropertyAccessor'></a>
## PropertyAccessor `type`

##### Namespace

Bb.Accessors

##### Summary

Property Accessor

<a name='M-Bb-Accessors-PropertyAccessor-#ctor-System-Type,System-Reflection-PropertyInfo,Bb-Accessors-MemberStrategy-'></a>
### #ctor(componentType,property) `constructor`

##### Summary

Initializes a new instance of the [PropertyAccessor](#T-Bb-Accessors-PropertyAccessor 'Bb.Accessors.PropertyAccessor') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| componentType | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | Type of the component. |
| property | [System.Reflection.PropertyInfo](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.PropertyInfo 'System.Reflection.PropertyInfo') | The property. |

<a name='T-Bb-Binders-PropertyBinder`2'></a>
## PropertyBinder\`2 `type`

##### Namespace

Bb.Binders

##### Summary

Property class observer for follow changes of the source instance

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TSource | Source type |
| TTarget | Target type |

##### Example

```csharp
    var source = new ObjectSource();
    var target = new ObjectTarget();
    
    var config = new PropertyBinder&lt;ObjectSource, ObjectTarget&gt;()
        .Bind(c =&gt; c.Name, (d, e) =&gt; d.Name = e);
    
    var observe = config.Observe(source, target);
    
    source.Name = "toto";
    Assert.Equal("toto", target.Name);
    
    source.Dispose();
    Assert.True(observe.IsDisposed);
```

<a name='M-Bb-Binders-PropertyBinder`2-#ctor'></a>
### #ctor() `constructor`

##### Summary

Initializes a new instance of the [PropertyBinder\`2](#T-Bb-Binders-PropertyBinder`2 'Bb.Binders.PropertyBinder`2') class.

##### Parameters

This constructor has no parameters.

<a name='M-Bb-Binders-PropertyBinder`2-Bind``1-System-Linq-Expressions-Expression{System-Func{`0,``0}},System-Action{`1,``0}-'></a>
### Bind\`\`1(expression,action) `method`

##### Summary

Method to bind a property

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| expression | [System.Linq.Expressions.Expression{System.Func{\`0,\`\`0}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression{System.Func{`0,``0}}') |  |
| action | [System.Action{\`1,\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{`1,``0}') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TValue |  |

<a name='M-Bb-Binders-PropertyBinder`2-Observe-`0,`1-'></a>
### Observe(source,target) `method`

##### Summary

Observe the source and update the target if the source change

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [\`0](#T-`0 '`0') |  |
| target | [\`1](#T-`1 '`1') |  |

<a name='T-Bb-Converters-ReflexionHelper'></a>
## ReflexionHelper `type`

##### Namespace

Bb.Converters

<a name='M-Bb-Converters-ReflexionHelper-GetMethodList-System-Type-'></a>
### GetMethodList(self) `method`

##### Summary

return methods

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') |  |

<a name='M-Bb-Converters-ReflexionHelper-GetMethods-System-Type,System-Func{System-Reflection-MethodInfo,System-Boolean}-'></a>
### GetMethods(self,filter) `method`

##### Summary

Return method list

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') |  |
| filter | [System.Func{System.Reflection.MethodInfo,System.Boolean}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Reflection.MethodInfo,System.Boolean}') |  |

<a name='T-Bb-Accessors-ValidationHelper'></a>
## ValidationHelper `type`

##### Namespace

Bb.Accessors

##### Summary

Validation Helper

<a name='M-Bb-Accessors-ValidationHelper-Validate-System-Object,System-Reflection-MemberInfo,System-Collections-Generic-IEnumerable{System-ComponentModel-DataAnnotations-ValidationAttribute}-'></a>
### Validate(dob,member,attributes) `method`

##### Summary

Validates the specified dob.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| dob | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The dob. |
| member | [System.Reflection.MemberInfo](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.MemberInfo 'System.Reflection.MemberInfo') | The member. |
| attributes | [System.Collections.Generic.IEnumerable{System.ComponentModel.DataAnnotations.ValidationAttribute}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{System.ComponentModel.DataAnnotations.ValidationAttribute}') | The attributes. |
