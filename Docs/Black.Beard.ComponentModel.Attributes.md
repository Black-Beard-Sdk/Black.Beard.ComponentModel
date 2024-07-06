<a name='assembly'></a>
# Black.Beard.ComponentModel.Attributes

## Contents

- [BusySession](#T-Bb-BusySession 'Bb.BusySession')
  - [#ctor(parent,parentInstance)](#M-Bb-BusySession-#ctor-Bb-IBusyService,System-String,System-Object,System-Action{Bb-BusySession}- 'Bb.BusySession.#ctor(Bb.IBusyService,System.String,System.Object,System.Action{Bb.BusySession})')
- [CultureProviderList](#T-Bb-ComponentModel-Attributes-CultureProviderList 'Bb.ComponentModel.Attributes.CultureProviderList')
  - [GetItems()](#M-Bb-ComponentModel-Attributes-CultureProviderList-GetItems 'Bb.ComponentModel.Attributes.CultureProviderList.GetItems')
- [DataTranslation](#T-Bb-ComponentModel-Translations-DataTranslation 'Bb.ComponentModel.Translations.DataTranslation')
  - [Culture](#P-Bb-ComponentModel-Translations-DataTranslation-Culture 'Bb.ComponentModel.Translations.DataTranslation.Culture')
  - [DefaultValueValue](#P-Bb-ComponentModel-Translations-DataTranslation-DefaultValueValue 'Bb.ComponentModel.Translations.DataTranslation.DefaultValueValue')
  - [Key](#P-Bb-ComponentModel-Translations-DataTranslation-Key 'Bb.ComponentModel.Translations.DataTranslation.Key')
  - [Path](#P-Bb-ComponentModel-Translations-DataTranslation-Path 'Bb.ComponentModel.Translations.DataTranslation.Path')
  - [Value](#P-Bb-ComponentModel-Translations-DataTranslation-Value 'Bb.ComponentModel.Translations.DataTranslation.Value')
- [DependOfAttribute](#T-Bb-ComponentModel-Attributes-DependOfAttribute 'Bb.ComponentModel.Attributes.DependOfAttribute')
  - [#ctor(type)](#M-Bb-ComponentModel-Attributes-DependOfAttribute-#ctor-System-Type- 'Bb.ComponentModel.Attributes.DependOfAttribute.#ctor(System.Type)')
- [EnumerationProviderAttribute](#T-Bb-ComponentModel-Attributes-EnumerationProviderAttribute 'Bb.ComponentModel.Attributes.EnumerationProviderAttribute')
- [ExposeClassAttribute](#T-Bb-ComponentModel-Attributes-ExposeClassAttribute 'Bb.ComponentModel.Attributes.ExposeClassAttribute')
  - [#ctor()](#M-Bb-ComponentModel-Attributes-ExposeClassAttribute-#ctor 'Bb.ComponentModel.Attributes.ExposeClassAttribute.#ctor')
  - [#ctor(context)](#M-Bb-ComponentModel-Attributes-ExposeClassAttribute-#ctor-System-String- 'Bb.ComponentModel.Attributes.ExposeClassAttribute.#ctor(System.String)')
  - [#ctor(context,display)](#M-Bb-ComponentModel-Attributes-ExposeClassAttribute-#ctor-System-String,System-String- 'Bb.ComponentModel.Attributes.ExposeClassAttribute.#ctor(System.String,System.String)')
  - [Context](#P-Bb-ComponentModel-Attributes-ExposeClassAttribute-Context 'Bb.ComponentModel.Attributes.ExposeClassAttribute.Context')
  - [ExposedType](#P-Bb-ComponentModel-Attributes-ExposeClassAttribute-ExposedType 'Bb.ComponentModel.Attributes.ExposeClassAttribute.ExposedType')
  - [LifeCycle](#P-Bb-ComponentModel-Attributes-ExposeClassAttribute-LifeCycle 'Bb.ComponentModel.Attributes.ExposeClassAttribute.LifeCycle')
  - [Name](#P-Bb-ComponentModel-Attributes-ExposeClassAttribute-Name 'Bb.ComponentModel.Attributes.ExposeClassAttribute.Name')
  - [Equals(obj)](#M-Bb-ComponentModel-Attributes-ExposeClassAttribute-Equals-System-Object- 'Bb.ComponentModel.Attributes.ExposeClassAttribute.Equals(System.Object)')
  - [GetHashCode()](#M-Bb-ComponentModel-Attributes-ExposeClassAttribute-GetHashCode 'Bb.ComponentModel.Attributes.ExposeClassAttribute.GetHashCode')
- [ExposeMethodAttribute](#T-Bb-ComponentModel-Attributes-ExposeMethodAttribute 'Bb.ComponentModel.Attributes.ExposeMethodAttribute')
  - [#ctor(displayName)](#M-Bb-ComponentModel-Attributes-ExposeMethodAttribute-#ctor-System-String- 'Bb.ComponentModel.Attributes.ExposeMethodAttribute.#ctor(System.String)')
- [ExposedAttributeTypeConfiguration](#T-Bb-ComponentModel-Attributes-ExposedAttributeTypeConfiguration 'Bb.ComponentModel.Attributes.ExposedAttributeTypeConfiguration')
  - [Context](#P-Bb-ComponentModel-Attributes-ExposedAttributeTypeConfiguration-Context 'Bb.ComponentModel.Attributes.ExposedAttributeTypeConfiguration.Context')
  - [ExposedType](#P-Bb-ComponentModel-Attributes-ExposedAttributeTypeConfiguration-ExposedType 'Bb.ComponentModel.Attributes.ExposedAttributeTypeConfiguration.ExposedType')
  - [LifeCycle](#P-Bb-ComponentModel-Attributes-ExposedAttributeTypeConfiguration-LifeCycle 'Bb.ComponentModel.Attributes.ExposedAttributeTypeConfiguration.LifeCycle')
  - [Name](#P-Bb-ComponentModel-Attributes-ExposedAttributeTypeConfiguration-Name 'Bb.ComponentModel.Attributes.ExposedAttributeTypeConfiguration.Name')
  - [TypeName](#P-Bb-ComponentModel-Attributes-ExposedAttributeTypeConfiguration-TypeName 'Bb.ComponentModel.Attributes.ExposedAttributeTypeConfiguration.TypeName')
- [ExposedTypeConfigurations](#T-Bb-ComponentModel-Attributes-ExposedTypeConfigurations 'Bb.ComponentModel.Attributes.ExposedTypeConfigurations')
- [IApplicationBuilderInitializer](#T-Bb-ComponentModel-Loaders-IApplicationBuilderInitializer 'Bb.ComponentModel.Loaders.IApplicationBuilderInitializer')
  - [Executed](#P-Bb-ComponentModel-Loaders-IApplicationBuilderInitializer-Executed 'Bb.ComponentModel.Loaders.IApplicationBuilderInitializer.Executed')
  - [FriendlyName](#P-Bb-ComponentModel-Loaders-IApplicationBuilderInitializer-FriendlyName 'Bb.ComponentModel.Loaders.IApplicationBuilderInitializer.FriendlyName')
  - [OrderPriority](#P-Bb-ComponentModel-Loaders-IApplicationBuilderInitializer-OrderPriority 'Bb.ComponentModel.Loaders.IApplicationBuilderInitializer.OrderPriority')
  - [Type](#P-Bb-ComponentModel-Loaders-IApplicationBuilderInitializer-Type 'Bb.ComponentModel.Loaders.IApplicationBuilderInitializer.Type')
- [IBusyService](#T-Bb-IBusyService 'Bb.IBusyService')
- [IInjectBuilder](#T-Bb-ComponentModel-IInjectBuilder 'Bb.ComponentModel.IInjectBuilder')
  - [FriendlyName](#P-Bb-ComponentModel-IInjectBuilder-FriendlyName 'Bb.ComponentModel.IInjectBuilder.FriendlyName')
  - [Type](#P-Bb-ComponentModel-IInjectBuilder-Type 'Bb.ComponentModel.IInjectBuilder.Type')
  - [CanExecute(context)](#M-Bb-ComponentModel-IInjectBuilder-CanExecute-System-Object- 'Bb.ComponentModel.IInjectBuilder.CanExecute(System.Object)')
  - [Execute(context)](#M-Bb-ComponentModel-IInjectBuilder-Execute-System-Object- 'Bb.ComponentModel.IInjectBuilder.Execute(System.Object)')
- [IInjectBuilder\`1](#T-Bb-ComponentModel-IInjectBuilder`1 'Bb.ComponentModel.IInjectBuilder`1')
  - [CanExecute(context)](#M-Bb-ComponentModel-IInjectBuilder`1-CanExecute-`0- 'Bb.ComponentModel.IInjectBuilder`1.CanExecute(`0)')
  - [Execute(context)](#M-Bb-ComponentModel-IInjectBuilder`1-Execute-`0- 'Bb.ComponentModel.IInjectBuilder`1.Execute(`0)')
- [IListProvider](#T-Bb-ComponentModel-DataAnnotations-IListProvider 'Bb.ComponentModel.DataAnnotations.IListProvider')
  - [Instance](#P-Bb-ComponentModel-DataAnnotations-IListProvider-Instance 'Bb.ComponentModel.DataAnnotations.IListProvider.Instance')
  - [Property](#P-Bb-ComponentModel-DataAnnotations-IListProvider-Property 'Bb.ComponentModel.DataAnnotations.IListProvider.Property')
  - [GetItems()](#M-Bb-ComponentModel-DataAnnotations-IListProvider-GetItems 'Bb.ComponentModel.DataAnnotations.IListProvider.GetItems')
  - [GetOriginalValue(item)](#M-Bb-ComponentModel-DataAnnotations-IListProvider-GetOriginalValue-Bb-ComponentModel-DataAnnotations-ListItem- 'Bb.ComponentModel.DataAnnotations.IListProvider.GetOriginalValue(Bb.ComponentModel.DataAnnotations.ListItem)')
- [ITranslateContainer](#T-Bb-ComponentModel-Translations-ITranslateContainer 'Bb.ComponentModel.Translations.ITranslateContainer')
  - [Add(key)](#M-Bb-ComponentModel-Translations-ITranslateContainer-Add-Bb-ComponentModel-Translations-TranslatedKeyLabel- 'Bb.ComponentModel.Translations.ITranslateContainer.Add(Bb.ComponentModel.Translations.TranslatedKeyLabel)')
  - [Get(key,culture)](#M-Bb-ComponentModel-Translations-ITranslateContainer-Get-Bb-ComponentModel-Translations-TranslatedKeyLabel,System-Globalization-CultureInfo- 'Bb.ComponentModel.Translations.ITranslateContainer.Get(Bb.ComponentModel.Translations.TranslatedKeyLabel,System.Globalization.CultureInfo)')
  - [Get(key)](#M-Bb-ComponentModel-Translations-ITranslateContainer-Get-Bb-ComponentModel-Translations-TranslatedKeyLabel- 'Bb.ComponentModel.Translations.ITranslateContainer.Get(Bb.ComponentModel.Translations.TranslatedKeyLabel)')
  - [GetAll(key)](#M-Bb-ComponentModel-Translations-ITranslateContainer-GetAll-Bb-ComponentModel-Translations-TranslatedKeyLabel- 'Bb.ComponentModel.Translations.ITranslateContainer.GetAll(Bb.ComponentModel.Translations.TranslatedKeyLabel)')
  - [Load()](#M-Bb-ComponentModel-Translations-ITranslateContainer-Load 'Bb.ComponentModel.Translations.ITranslateContainer.Load')
  - [Save()](#M-Bb-ComponentModel-Translations-ITranslateContainer-Save 'Bb.ComponentModel.Translations.ITranslateContainer.Save')
- [ITranslateHost](#T-Bb-ComponentModel-Translations-ITranslateHost 'Bb.ComponentModel.Translations.ITranslateHost')
- [ITranslateService](#T-Bb-ComponentModel-Translations-ITranslateService 'Bb.ComponentModel.Translations.ITranslateService')
  - [AvailableCultures](#P-Bb-ComponentModel-Translations-ITranslateService-AvailableCultures 'Bb.ComponentModel.Translations.ITranslateService.AvailableCultures')
  - [Container](#P-Bb-ComponentModel-Translations-ITranslateService-Container 'Bb.ComponentModel.Translations.ITranslateService.Container')
  - [Translate(key,arguments)](#M-Bb-ComponentModel-Translations-ITranslateService-Translate-Bb-ComponentModel-Translations-TranslatedKeyLabel,Bb-ComponentModel-Translations-TranslatedKeyLabel[]- 'Bb.ComponentModel.Translations.ITranslateService.Translate(Bb.ComponentModel.Translations.TranslatedKeyLabel,Bb.ComponentModel.Translations.TranslatedKeyLabel[])')
  - [Translate(culture,key,arguments)](#M-Bb-ComponentModel-Translations-ITranslateService-Translate-System-Globalization-CultureInfo,Bb-ComponentModel-Translations-TranslatedKeyLabel,Bb-ComponentModel-Translations-TranslatedKeyLabel[]- 'Bb.ComponentModel.Translations.ITranslateService.Translate(System.Globalization.CultureInfo,Bb.ComponentModel.Translations.TranslatedKeyLabel,Bb.ComponentModel.Translations.TranslatedKeyLabel[])')
- [IUIComponent](#T-Bb-ComponentModel-IUIComponent 'Bb.ComponentModel.IUIComponent')
  - [GetService(type)](#M-Bb-ComponentModel-IUIComponent-GetService-System-Type- 'Bb.ComponentModel.IUIComponent.GetService(System.Type)')
- [IUISite](#T-Bb-ComponentModel-IUISite 'Bb.ComponentModel.IUISite')
  - [Parent](#P-Bb-ComponentModel-IUISite-Parent 'Bb.ComponentModel.IUISite.Parent')
- [InjectorPolicyAttribute](#T-Bb-ComponentModel-Attributes-InjectorPolicyAttribute 'Bb.ComponentModel.Attributes.InjectorPolicyAttribute')
  - [#ctor(type,lifeCycle)](#M-Bb-ComponentModel-Attributes-InjectorPolicyAttribute-#ctor-System-Type,Bb-ComponentModel-Attributes-IocScopeEnum- 'Bb.ComponentModel.Attributes.InjectorPolicyAttribute.#ctor(System.Type,Bb.ComponentModel.Attributes.IocScopeEnum)')
  - [LifeCycle](#P-Bb-ComponentModel-Attributes-InjectorPolicyAttribute-LifeCycle 'Bb.ComponentModel.Attributes.InjectorPolicyAttribute.LifeCycle')
  - [Type](#P-Bb-ComponentModel-Attributes-InjectorPolicyAttribute-Type 'Bb.ComponentModel.Attributes.InjectorPolicyAttribute.Type')
- [ListItem](#T-Bb-ComponentModel-DataAnnotations-ListItem 'Bb.ComponentModel.DataAnnotations.ListItem')
  - [Disabled](#P-Bb-ComponentModel-DataAnnotations-ListItem-Disabled 'Bb.ComponentModel.DataAnnotations.ListItem.Disabled')
  - [Display](#P-Bb-ComponentModel-DataAnnotations-ListItem-Display 'Bb.ComponentModel.DataAnnotations.ListItem.Display')
  - [Name](#P-Bb-ComponentModel-DataAnnotations-ListItem-Name 'Bb.ComponentModel.DataAnnotations.ListItem.Name')
  - [Selected](#P-Bb-ComponentModel-DataAnnotations-ListItem-Selected 'Bb.ComponentModel.DataAnnotations.ListItem.Selected')
  - [Source](#P-Bb-ComponentModel-DataAnnotations-ListItem-Source 'Bb.ComponentModel.DataAnnotations.ListItem.Source')
  - [Value](#P-Bb-ComponentModel-DataAnnotations-ListItem-Value 'Bb.ComponentModel.DataAnnotations.ListItem.Value')
  - [Compare(right)](#M-Bb-ComponentModel-DataAnnotations-ListItem-Compare-System-Object- 'Bb.ComponentModel.DataAnnotations.ListItem.Compare(System.Object)')
  - [Equals(o)](#M-Bb-ComponentModel-DataAnnotations-ListItem-Equals-System-Object- 'Bb.ComponentModel.DataAnnotations.ListItem.Equals(System.Object)')
  - [GetHashCode()](#M-Bb-ComponentModel-DataAnnotations-ListItem-GetHashCode 'Bb.ComponentModel.DataAnnotations.ListItem.GetHashCode')
  - [GetOriginalValue()](#M-Bb-ComponentModel-DataAnnotations-ListItem-GetOriginalValue 'Bb.ComponentModel.DataAnnotations.ListItem.GetOriginalValue')
  - [ToString()](#M-Bb-ComponentModel-DataAnnotations-ListItem-ToString 'Bb.ComponentModel.DataAnnotations.ListItem.ToString')
- [ListItem\`1](#T-Bb-ComponentModel-DataAnnotations-ListItem`1 'Bb.ComponentModel.DataAnnotations.ListItem`1')
  - [Tag](#P-Bb-ComponentModel-DataAnnotations-ListItem`1-Tag 'Bb.ComponentModel.DataAnnotations.ListItem`1.Tag')
- [ListProviderAttribute](#T-Bb-ComponentModel-Attributes-ListProviderAttribute 'Bb.ComponentModel.Attributes.ListProviderAttribute')
  - [#ctor(typeListResolver,property,instance)](#M-Bb-ComponentModel-Attributes-ListProviderAttribute-#ctor-System-Type- 'Bb.ComponentModel.Attributes.ListProviderAttribute.#ctor(System.Type)')
  - [GetProvider()](#M-Bb-ComponentModel-Attributes-ListProviderAttribute-GetProvider-System-ComponentModel-PropertyDescriptor,System-Object- 'Bb.ComponentModel.Attributes.ListProviderAttribute.GetProvider(System.ComponentModel.PropertyDescriptor,System.Object)')
  - [GetProvider(provider,property,instance)](#M-Bb-ComponentModel-Attributes-ListProviderAttribute-GetProvider-System-IServiceProvider,System-ComponentModel-PropertyDescriptor,System-Object- 'Bb.ComponentModel.Attributes.ListProviderAttribute.GetProvider(System.IServiceProvider,System.ComponentModel.PropertyDescriptor,System.Object)')
- [MetaPropertyAttribute](#T-Bb-ComponentModel-Attributes-MetaPropertyAttribute 'Bb.ComponentModel.Attributes.MetaPropertyAttribute')
  - [#ctor(context,name,value)](#M-Bb-ComponentModel-Attributes-MetaPropertyAttribute-#ctor-System-String,System-String,System-Object- 'Bb.ComponentModel.Attributes.MetaPropertyAttribute.#ctor(System.String,System.String,System.Object)')
  - [Context](#P-Bb-ComponentModel-Attributes-MetaPropertyAttribute-Context 'Bb.ComponentModel.Attributes.MetaPropertyAttribute.Context')
  - [Name](#P-Bb-ComponentModel-Attributes-MetaPropertyAttribute-Name 'Bb.ComponentModel.Attributes.MetaPropertyAttribute.Name')
  - [Type](#P-Bb-ComponentModel-Attributes-MetaPropertyAttribute-Type 'Bb.ComponentModel.Attributes.MetaPropertyAttribute.Type')
  - [Value](#P-Bb-ComponentModel-Attributes-MetaPropertyAttribute-Value 'Bb.ComponentModel.Attributes.MetaPropertyAttribute.Value')
- [PriorityHelper](#T-Bb-ComponentModel-Attributes-PriorityHelper 'Bb.ComponentModel.Attributes.PriorityHelper')
  - [OrderByPriority(types)](#M-Bb-ComponentModel-Attributes-PriorityHelper-OrderByPriority-System-Collections-Generic-IEnumerable{System-Type}- 'Bb.ComponentModel.Attributes.PriorityHelper.OrderByPriority(System.Collections.Generic.IEnumerable{System.Type})')
- [ProviderListBase\`1](#T-Bb-ComponentModel-Attributes-ProviderListBase`1 'Bb.ComponentModel.Attributes.ProviderListBase`1')
  - [Instance](#P-Bb-ComponentModel-Attributes-ProviderListBase`1-Instance 'Bb.ComponentModel.Attributes.ProviderListBase`1.Instance')
  - [Property](#P-Bb-ComponentModel-Attributes-ProviderListBase`1-Property 'Bb.ComponentModel.Attributes.ProviderListBase`1.Property')
  - [CreateItem(instance)](#M-Bb-ComponentModel-Attributes-ProviderListBase`1-CreateItem-`0,System-String,System-Object,System-Action{Bb-ComponentModel-DataAnnotations-ListItem{`0}}- 'Bb.ComponentModel.Attributes.ProviderListBase`1.CreateItem(`0,System.String,System.Object,System.Action{Bb.ComponentModel.DataAnnotations.ListItem{`0}})')
  - [GetItems()](#M-Bb-ComponentModel-Attributes-ProviderListBase`1-GetItems 'Bb.ComponentModel.Attributes.ProviderListBase`1.GetItems')
  - [ResolveOriginalValue(item)](#M-Bb-ComponentModel-Attributes-ProviderListBase`1-ResolveOriginalValue-Bb-ComponentModel-DataAnnotations-ListItem{`0}- 'Bb.ComponentModel.Attributes.ProviderListBase`1.ResolveOriginalValue(Bb.ComponentModel.DataAnnotations.ListItem{`0})')
- [TranslatedKeyLabel](#T-Bb-ComponentModel-Translations-TranslatedKeyLabel 'Bb.ComponentModel.Translations.TranslatedKeyLabel')
  - [#ctor()](#M-Bb-ComponentModel-Translations-TranslatedKeyLabel-#ctor 'Bb.ComponentModel.Translations.TranslatedKeyLabel.#ctor')
  - [#ctor(defaultDisplay)](#M-Bb-ComponentModel-Translations-TranslatedKeyLabel-#ctor-System-String- 'Bb.ComponentModel.Translations.TranslatedKeyLabel.#ctor(System.String)')
  - [#ctor(path,defaultDisplay)](#M-Bb-ComponentModel-Translations-TranslatedKeyLabel-#ctor-System-String,System-String- 'Bb.ComponentModel.Translations.TranslatedKeyLabel.#ctor(System.String,System.String)')
  - [#ctor(path,defaultDisplay,key,culture)](#M-Bb-ComponentModel-Translations-TranslatedKeyLabel-#ctor-System-String,System-String,System-String,System-Globalization-CultureInfo- 'Bb.ComponentModel.Translations.TranslatedKeyLabel.#ctor(System.String,System.String,System.String,System.Globalization.CultureInfo)')
  - [DebugTrace](#P-Bb-ComponentModel-Translations-TranslatedKeyLabel-DebugTrace 'Bb.ComponentModel.Translations.TranslatedKeyLabel.DebugTrace')
  - [DefaultCulture](#P-Bb-ComponentModel-Translations-TranslatedKeyLabel-DefaultCulture 'Bb.ComponentModel.Translations.TranslatedKeyLabel.DefaultCulture')
  - [DefaultDisplay](#P-Bb-ComponentModel-Translations-TranslatedKeyLabel-DefaultDisplay 'Bb.ComponentModel.Translations.TranslatedKeyLabel.DefaultDisplay')
  - [EmptyKey](#P-Bb-ComponentModel-Translations-TranslatedKeyLabel-EmptyKey 'Bb.ComponentModel.Translations.TranslatedKeyLabel.EmptyKey')
  - [IsNotValidKey](#P-Bb-ComponentModel-Translations-TranslatedKeyLabel-IsNotValidKey 'Bb.ComponentModel.Translations.TranslatedKeyLabel.IsNotValidKey')
  - [Item](#P-Bb-ComponentModel-Translations-TranslatedKeyLabel-Item-System-Globalization-CultureInfo- 'Bb.ComponentModel.Translations.TranslatedKeyLabel.Item(System.Globalization.CultureInfo)')
  - [Key](#P-Bb-ComponentModel-Translations-TranslatedKeyLabel-Key 'Bb.ComponentModel.Translations.TranslatedKeyLabel.Key')
  - [ModeDebug](#P-Bb-ComponentModel-Translations-TranslatedKeyLabel-ModeDebug 'Bb.ComponentModel.Translations.TranslatedKeyLabel.ModeDebug')
  - [Path](#P-Bb-ComponentModel-Translations-TranslatedKeyLabel-Path 'Bb.ComponentModel.Translations.TranslatedKeyLabel.Path')
  - [Translations](#P-Bb-ComponentModel-Translations-TranslatedKeyLabel-Translations 'Bb.ComponentModel.Translations.TranslatedKeyLabel.Translations')
  - [Equals(obj)](#M-Bb-ComponentModel-Translations-TranslatedKeyLabel-Equals-System-Object- 'Bb.ComponentModel.Translations.TranslatedKeyLabel.Equals(System.Object)')
  - [IsValid(key)](#M-Bb-ComponentModel-Translations-TranslatedKeyLabel-IsValid-System-String- 'Bb.ComponentModel.Translations.TranslatedKeyLabel.IsValid(System.String)')
  - [Parse(key)](#M-Bb-ComponentModel-Translations-TranslatedKeyLabel-Parse-System-String- 'Bb.ComponentModel.Translations.TranslatedKeyLabel.Parse(System.String)')
  - [ToString()](#M-Bb-ComponentModel-Translations-TranslatedKeyLabel-ToString 'Bb.ComponentModel.Translations.TranslatedKeyLabel.ToString')
  - [Translate(service,arguments)](#M-Bb-ComponentModel-Translations-TranslatedKeyLabel-Translate-Bb-ComponentModel-Translations-ITranslateHost,Bb-ComponentModel-Translations-TranslatedKeyLabel[]- 'Bb.ComponentModel.Translations.TranslatedKeyLabel.Translate(Bb.ComponentModel.Translations.ITranslateHost,Bb.ComponentModel.Translations.TranslatedKeyLabel[])')
  - [Translate(service,arguments)](#M-Bb-ComponentModel-Translations-TranslatedKeyLabel-Translate-Bb-ComponentModel-Translations-ITranslateService,Bb-ComponentModel-Translations-TranslatedKeyLabel[]- 'Bb.ComponentModel.Translations.TranslatedKeyLabel.Translate(Bb.ComponentModel.Translations.ITranslateService,Bb.ComponentModel.Translations.TranslatedKeyLabel[])')
  - [TryConvert(key,keyLabel)](#M-Bb-ComponentModel-Translations-TranslatedKeyLabel-TryConvert-System-String,Bb-ComponentModel-Translations-TranslatedKeyLabel@- 'Bb.ComponentModel.Translations.TranslatedKeyLabel.TryConvert(System.String,Bb.ComponentModel.Translations.TranslatedKeyLabel@)')
- [TranslatedKeyLabelExtension](#T-Bb-ComponentModel-Translations-TranslatedKeyLabelExtension 'Bb.ComponentModel.Translations.TranslatedKeyLabelExtension')
  - [GetFrom(info)](#M-Bb-ComponentModel-Translations-TranslatedKeyLabelExtension-GetFrom-System-Reflection-MemberInfo- 'Bb.ComponentModel.Translations.TranslatedKeyLabelExtension.GetFrom(System.Reflection.MemberInfo)')
  - [IsValidTranslationKey(self)](#M-Bb-ComponentModel-Translations-TranslatedKeyLabelExtension-IsValidTranslationKey-System-String- 'Bb.ComponentModel.Translations.TranslatedKeyLabelExtension.IsValidTranslationKey(System.String)')
  - [TryConvertInTranslationKey(self,key)](#M-Bb-ComponentModel-Translations-TranslatedKeyLabelExtension-TryConvertInTranslationKey-System-String,Bb-ComponentModel-Translations-TranslatedKeyLabel@- 'Bb.ComponentModel.Translations.TranslatedKeyLabelExtension.TryConvertInTranslationKey(System.String,Bb.ComponentModel.Translations.TranslatedKeyLabel@)')
- [TranslationKeyAttribute](#T-Bb-ComponentModel-Attributes-TranslationKeyAttribute 'Bb.ComponentModel.Attributes.TranslationKeyAttribute')
  - [#ctor(translationKey)](#M-Bb-ComponentModel-Attributes-TranslationKeyAttribute-#ctor-System-String- 'Bb.ComponentModel.Attributes.TranslationKeyAttribute.#ctor(System.String)')
  - [#ctor(context,translationKey)](#M-Bb-ComponentModel-Attributes-TranslationKeyAttribute-#ctor-System-String,System-String- 'Bb.ComponentModel.Attributes.TranslationKeyAttribute.#ctor(System.String,System.String)')
  - [Context](#P-Bb-ComponentModel-Attributes-TranslationKeyAttribute-Context 'Bb.ComponentModel.Attributes.TranslationKeyAttribute.Context')
  - [Key](#P-Bb-ComponentModel-Attributes-TranslationKeyAttribute-Key 'Bb.ComponentModel.Attributes.TranslationKeyAttribute.Key')
- [TypeDescriptorExtension](#T-Bb-ComponentModel-TypeDescriptorExtension 'Bb.ComponentModel.TypeDescriptorExtension')
  - [GetProperties(self)](#M-Bb-ComponentModel-TypeDescriptorExtension-GetProperties-System-Type- 'Bb.ComponentModel.TypeDescriptorExtension.GetProperties(System.Type)')
  - [GetProperties(self,funcFilter)](#M-Bb-ComponentModel-TypeDescriptorExtension-GetProperties-System-Type,System-Func{System-ComponentModel-PropertyDescriptor,System-Boolean}- 'Bb.ComponentModel.TypeDescriptorExtension.GetProperties(System.Type,System.Func{System.ComponentModel.PropertyDescriptor,System.Boolean})')

<a name='T-Bb-BusySession'></a>
## BusySession `type`

##### Namespace

Bb

<a name='M-Bb-BusySession-#ctor-Bb-IBusyService,System-String,System-Object,System-Action{Bb-BusySession}-'></a>
### #ctor(parent,parentInstance) `constructor`

##### Summary



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| parent | [Bb.IBusyService](#T-Bb-IBusyService 'Bb.IBusyService') |  |
| parentInstance | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='T-Bb-ComponentModel-Attributes-CultureProviderList'></a>
## CultureProviderList `type`

##### Namespace

Bb.ComponentModel.Attributes

<a name='M-Bb-ComponentModel-Attributes-CultureProviderList-GetItems'></a>
### GetItems() `method`

##### Summary

Get the list of items

##### Returns



##### Parameters

This method has no parameters.

<a name='T-Bb-ComponentModel-Translations-DataTranslation'></a>
## DataTranslation `type`

##### Namespace

Bb.ComponentModel.Translations

<a name='P-Bb-ComponentModel-Translations-DataTranslation-Culture'></a>
### Culture `property`

##### Summary

Culture of the translation

<a name='P-Bb-ComponentModel-Translations-DataTranslation-DefaultValueValue'></a>
### DefaultValueValue `property`

##### Summary

return the default value of the parent

<a name='P-Bb-ComponentModel-Translations-DataTranslation-Key'></a>
### Key `property`

##### Summary

Translation key

<a name='P-Bb-ComponentModel-Translations-DataTranslation-Path'></a>
### Path `property`

##### Summary

Contract of the translation key

<a name='P-Bb-ComponentModel-Translations-DataTranslation-Value'></a>
### Value `property`

##### Summary



<a name='T-Bb-ComponentModel-Attributes-DependOfAttribute'></a>
## DependOfAttribute `type`

##### Namespace

Bb.ComponentModel.Attributes

<a name='M-Bb-ComponentModel-Attributes-DependOfAttribute-#ctor-System-Type-'></a>
### #ctor(type) `constructor`

##### Summary

Ctor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') |  |

<a name='T-Bb-ComponentModel-Attributes-EnumerationProviderAttribute'></a>
## EnumerationProviderAttribute `type`

##### Namespace

Bb.ComponentModel.Attributes

##### Summary

Enumeration provider attribute

<a name='T-Bb-ComponentModel-Attributes-ExposeClassAttribute'></a>
## ExposeClassAttribute `type`

##### Namespace

Bb.ComponentModel.Attributes

##### Summary

specify this class contains method to expose

<a name='M-Bb-ComponentModel-Attributes-ExposeClassAttribute-#ctor'></a>
### #ctor() `constructor`

##### Summary

Initializes a new instance of the [ExposeClassAttribute](#T-Bb-ComponentModel-Attributes-ExposeClassAttribute 'Bb.ComponentModel.Attributes.ExposeClassAttribute') class.

##### Parameters

This constructor has no parameters.

<a name='M-Bb-ComponentModel-Attributes-ExposeClassAttribute-#ctor-System-String-'></a>
### #ctor(context) `constructor`

##### Summary

Initializes a new instance of the [ExposeClassAttribute](#T-Bb-ComponentModel-Attributes-ExposeClassAttribute 'Bb.ComponentModel.Attributes.ExposeClassAttribute') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| context | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | key for matching context |

<a name='M-Bb-ComponentModel-Attributes-ExposeClassAttribute-#ctor-System-String,System-String-'></a>
### #ctor(context,display) `constructor`

##### Summary

Initializes a new instance of the [ExposeClassAttribute](#T-Bb-ComponentModel-Attributes-ExposeClassAttribute 'Bb.ComponentModel.Attributes.ExposeClassAttribute') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| context | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | key for matching context |
| display | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The display. |

<a name='P-Bb-ComponentModel-Attributes-ExposeClassAttribute-Context'></a>
### Context `property`

##### Summary

Gets or sets the context of the class exposed by this attribute.

<a name='P-Bb-ComponentModel-Attributes-ExposeClassAttribute-ExposedType'></a>
### ExposedType `property`

##### Summary

Gets or sets the exposition type.

<a name='P-Bb-ComponentModel-Attributes-ExposeClassAttribute-LifeCycle'></a>
### LifeCycle `property`

##### Summary

Gets or sets the life cycle if must be use in Ioc.

<a name='P-Bb-ComponentModel-Attributes-ExposeClassAttribute-Name'></a>
### Name `property`

##### Summary

Gets or sets the display name.

<a name='M-Bb-ComponentModel-Attributes-ExposeClassAttribute-Equals-System-Object-'></a>
### Equals(obj) `method`

##### Summary

Determines whether the specified [Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object'), is equal to this instance.

##### Returns

`true` if the specified [Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') is equal to this instance; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| obj | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The [Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') to compare with this instance. |

<a name='M-Bb-ComponentModel-Attributes-ExposeClassAttribute-GetHashCode'></a>
### GetHashCode() `method`

##### Summary

Returns a hash code for this instance.

##### Returns

A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.

##### Parameters

This method has no parameters.

<a name='T-Bb-ComponentModel-Attributes-ExposeMethodAttribute'></a>
## ExposeMethodAttribute `type`

##### Namespace

Bb.ComponentModel.Attributes

<a name='M-Bb-ComponentModel-Attributes-ExposeMethodAttribute-#ctor-System-String-'></a>
### #ctor(displayName) `constructor`

##### Summary



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| displayName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | key for matching ruless |

<a name='T-Bb-ComponentModel-Attributes-ExposedAttributeTypeConfiguration'></a>
## ExposedAttributeTypeConfiguration `type`

##### Namespace

Bb.ComponentModel.Attributes

<a name='P-Bb-ComponentModel-Attributes-ExposedAttributeTypeConfiguration-Context'></a>
### Context `property`

##### Summary

Gets or sets the context.

<a name='P-Bb-ComponentModel-Attributes-ExposedAttributeTypeConfiguration-ExposedType'></a>
### ExposedType `property`

##### Summary

Gets or sets the exposition type.

<a name='P-Bb-ComponentModel-Attributes-ExposedAttributeTypeConfiguration-LifeCycle'></a>
### LifeCycle `property`

##### Summary

Gets or sets the life cycle.

<a name='P-Bb-ComponentModel-Attributes-ExposedAttributeTypeConfiguration-Name'></a>
### Name `property`

##### Summary

Gets or sets the name.

<a name='P-Bb-ComponentModel-Attributes-ExposedAttributeTypeConfiguration-TypeName'></a>
### TypeName `property`

##### Summary

Gets or sets the name of the type.

<a name='T-Bb-ComponentModel-Attributes-ExposedTypeConfigurations'></a>
## ExposedTypeConfigurations `type`

##### Namespace

Bb.ComponentModel.Attributes

##### Summary

Configuration to register Exposition manually

##### See Also

- [System.Collections.Generic.List<Bb.ComponentModel.ExposedTypeConfiguration>](#!-System-Collections-Generic-List<Bb-ComponentModel-ExposedTypeConfiguration> 'System.Collections.Generic.List<Bb.ComponentModel.ExposedTypeConfiguration>')

<a name='T-Bb-ComponentModel-Loaders-IApplicationBuilderInitializer'></a>
## IApplicationBuilderInitializer `type`

##### Namespace

Bb.ComponentModel.Loaders

<a name='P-Bb-ComponentModel-Loaders-IApplicationBuilderInitializer-Executed'></a>
### Executed `property`

##### Summary

return true if the builder has been Initialized

<a name='P-Bb-ComponentModel-Loaders-IApplicationBuilderInitializer-FriendlyName'></a>
### FriendlyName `property`

##### Summary

Friendly name of the builder

<a name='P-Bb-ComponentModel-Loaders-IApplicationBuilderInitializer-OrderPriority'></a>
### OrderPriority `property`

##### Summary

Order of initialization

<a name='P-Bb-ComponentModel-Loaders-IApplicationBuilderInitializer-Type'></a>
### Type `property`

##### Summary

Return the type of service that should be passed by argument

<a name='T-Bb-IBusyService'></a>
## IBusyService `type`

##### Namespace

Bb

##### Summary

Busy service

<a name='T-Bb-ComponentModel-IInjectBuilder'></a>
## IInjectBuilder `type`

##### Namespace

Bb.ComponentModel

##### Summary

Generic interface for Initialize service

<a name='P-Bb-ComponentModel-IInjectBuilder-FriendlyName'></a>
### FriendlyName `property`

##### Summary

Friendly name of the builder

<a name='P-Bb-ComponentModel-IInjectBuilder-Type'></a>
### Type `property`

##### Summary

Return the type of service that should be passed by argument

<a name='M-Bb-ComponentModel-IInjectBuilder-CanExecute-System-Object-'></a>
### CanExecute(context) `method`

##### Summary

Return true if the process can be run

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| context | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | specified context [Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') |

<a name='M-Bb-ComponentModel-IInjectBuilder-Execute-System-Object-'></a>
### Execute(context) `method`

##### Summary

Execute the initializing process with [Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object')

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| context | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | specified context [Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') |

<a name='T-Bb-ComponentModel-IInjectBuilder`1'></a>
## IInjectBuilder\`1 `type`

##### Namespace

Bb.ComponentModel

##### Summary

specialized interface for Initialize service

<a name='M-Bb-ComponentModel-IInjectBuilder`1-CanExecute-`0-'></a>
### CanExecute(context) `method`

##### Summary

Return true if the process can be run

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| context | [\`0](#T-`0 '`0') | specified context [](#!-T 'T') |

<a name='M-Bb-ComponentModel-IInjectBuilder`1-Execute-`0-'></a>
### Execute(context) `method`

##### Summary

Execute the initializing process with [](#!-T 'T')

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| context | [\`0](#T-`0 '`0') | specified context [](#!-T 'T') |

<a name='T-Bb-ComponentModel-DataAnnotations-IListProvider'></a>
## IListProvider `type`

##### Namespace

Bb.ComponentModel.DataAnnotations

##### Summary

Provides a list of items for a property.

<a name='P-Bb-ComponentModel-DataAnnotations-IListProvider-Instance'></a>
### Instance `property`

##### Summary

Gets or sets the instance. for th property

<a name='P-Bb-ComponentModel-DataAnnotations-IListProvider-Property'></a>
### Property `property`

##### Summary

Gets or sets the property descriptor.

<a name='M-Bb-ComponentModel-DataAnnotations-IListProvider-GetItems'></a>
### GetItems() `method`

##### Summary

Gets the items list.

##### Returns



##### Parameters

This method has no parameters.

<a name='M-Bb-ComponentModel-DataAnnotations-IListProvider-GetOriginalValue-Bb-ComponentModel-DataAnnotations-ListItem-'></a>
### GetOriginalValue(item) `method`

##### Summary

Return the new value that can be set in the property

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| item | [Bb.ComponentModel.DataAnnotations.ListItem](#T-Bb-ComponentModel-DataAnnotations-ListItem 'Bb.ComponentModel.DataAnnotations.ListItem') | ListItem source |

<a name='T-Bb-ComponentModel-Translations-ITranslateContainer'></a>
## ITranslateContainer `type`

##### Namespace

Bb.ComponentModel.Translations

<a name='M-Bb-ComponentModel-Translations-ITranslateContainer-Add-Bb-ComponentModel-Translations-TranslatedKeyLabel-'></a>
### Add(key) `method`

##### Summary

Add a new key in the referential

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| key | [Bb.ComponentModel.Translations.TranslatedKeyLabel](#T-Bb-ComponentModel-Translations-TranslatedKeyLabel 'Bb.ComponentModel.Translations.TranslatedKeyLabel') |  |

<a name='M-Bb-ComponentModel-Translations-ITranslateContainer-Get-Bb-ComponentModel-Translations-TranslatedKeyLabel,System-Globalization-CultureInfo-'></a>
### Get(key,culture) `method`

##### Summary

Return a translation for the key and the culture

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| key | [Bb.ComponentModel.Translations.TranslatedKeyLabel](#T-Bb-ComponentModel-Translations-TranslatedKeyLabel 'Bb.ComponentModel.Translations.TranslatedKeyLabel') | key translation |
| culture | [System.Globalization.CultureInfo](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Globalization.CultureInfo 'System.Globalization.CultureInfo') | culture target |

<a name='M-Bb-ComponentModel-Translations-ITranslateContainer-Get-Bb-ComponentModel-Translations-TranslatedKeyLabel-'></a>
### Get(key) `method`

##### Summary

Return a translation for the key mapped to the current culture

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| key | [Bb.ComponentModel.Translations.TranslatedKeyLabel](#T-Bb-ComponentModel-Translations-TranslatedKeyLabel 'Bb.ComponentModel.Translations.TranslatedKeyLabel') |  |

<a name='M-Bb-ComponentModel-Translations-ITranslateContainer-GetAll-Bb-ComponentModel-Translations-TranslatedKeyLabel-'></a>
### GetAll(key) `method`

##### Summary

Return a translation for the key mapped with culture

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| key | [Bb.ComponentModel.Translations.TranslatedKeyLabel](#T-Bb-ComponentModel-Translations-TranslatedKeyLabel 'Bb.ComponentModel.Translations.TranslatedKeyLabel') |  |

<a name='M-Bb-ComponentModel-Translations-ITranslateContainer-Load'></a>
### Load() `method`

##### Summary

Load the translations

##### Parameters

This method has no parameters.

<a name='M-Bb-ComponentModel-Translations-ITranslateContainer-Save'></a>
### Save() `method`

##### Summary

save the translations

##### Parameters

This method has no parameters.

<a name='T-Bb-ComponentModel-Translations-ITranslateHost'></a>
## ITranslateHost `type`

##### Namespace

Bb.ComponentModel.Translations

##### Summary

Contract for translation service

<a name='T-Bb-ComponentModel-Translations-ITranslateService'></a>
## ITranslateService `type`

##### Namespace

Bb.ComponentModel.Translations

##### Summary

Contract for translation service

<a name='P-Bb-ComponentModel-Translations-ITranslateService-AvailableCultures'></a>
### AvailableCultures `property`

##### Summary

return the list of available cultures

<a name='P-Bb-ComponentModel-Translations-ITranslateService-Container'></a>
### Container `property`

##### Summary

Container for store the keys

<a name='M-Bb-ComponentModel-Translations-ITranslateService-Translate-Bb-ComponentModel-Translations-TranslatedKeyLabel,Bb-ComponentModel-Translations-TranslatedKeyLabel[]-'></a>
### Translate(key,arguments) `method`

##### Summary

Translate the key and return the value for the current culture

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| key | [Bb.ComponentModel.Translations.TranslatedKeyLabel](#T-Bb-ComponentModel-Translations-TranslatedKeyLabel 'Bb.ComponentModel.Translations.TranslatedKeyLabel') | translation key |
| arguments | [Bb.ComponentModel.Translations.TranslatedKeyLabel[]](#T-Bb-ComponentModel-Translations-TranslatedKeyLabel[] 'Bb.ComponentModel.Translations.TranslatedKeyLabel[]') | translation keys arguments. (if the result of the translation contains "{\d}", a String.Format is apply with specified arguments |

##### Example

"Do you want to delete item {0}"

<a name='M-Bb-ComponentModel-Translations-ITranslateService-Translate-System-Globalization-CultureInfo,Bb-ComponentModel-Translations-TranslatedKeyLabel,Bb-ComponentModel-Translations-TranslatedKeyLabel[]-'></a>
### Translate(culture,key,arguments) `method`

##### Summary

Translate the key and return the value for the specified culture

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| culture | [System.Globalization.CultureInfo](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Globalization.CultureInfo 'System.Globalization.CultureInfo') | culture asked |
| key | [Bb.ComponentModel.Translations.TranslatedKeyLabel](#T-Bb-ComponentModel-Translations-TranslatedKeyLabel 'Bb.ComponentModel.Translations.TranslatedKeyLabel') | translation key |
| arguments | [Bb.ComponentModel.Translations.TranslatedKeyLabel[]](#T-Bb-ComponentModel-Translations-TranslatedKeyLabel[] 'Bb.ComponentModel.Translations.TranslatedKeyLabel[]') | translation keys arguments. (if the result of the translation contains "{\d}" a String.Format is apply with specified arguments |

##### Example

"Do you want to delete item {0}"

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

<a name='T-Bb-ComponentModel-Attributes-InjectorPolicyAttribute'></a>
## InjectorPolicyAttribute `type`

##### Namespace

Bb.ComponentModel.Attributes

##### Summary

Add a policy for the Ioc

<a name='M-Bb-ComponentModel-Attributes-InjectorPolicyAttribute-#ctor-System-Type,Bb-ComponentModel-Attributes-IocScopeEnum-'></a>
### #ctor(type,lifeCycle) `constructor`

##### Summary

Ctor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') |  |
| lifeCycle | [Bb.ComponentModel.Attributes.IocScopeEnum](#T-Bb-ComponentModel-Attributes-IocScopeEnum 'Bb.ComponentModel.Attributes.IocScopeEnum') |  |

<a name='P-Bb-ComponentModel-Attributes-InjectorPolicyAttribute-LifeCycle'></a>
### LifeCycle `property`

##### Summary

Gets or sets the life cycle if must be use in Ioc.

<a name='P-Bb-ComponentModel-Attributes-InjectorPolicyAttribute-Type'></a>
### Type `property`

##### Summary

Gets the type.

<a name='T-Bb-ComponentModel-DataAnnotations-ListItem'></a>
## ListItem `type`

##### Namespace

Bb.ComponentModel.DataAnnotations

##### Summary

Represents a list item.

<a name='P-Bb-ComponentModel-DataAnnotations-ListItem-Disabled'></a>
### Disabled `property`

##### Summary

Gets or sets the item is disabled.

<a name='P-Bb-ComponentModel-DataAnnotations-ListItem-Display'></a>
### Display `property`

##### Summary

Gets or sets the display.

<a name='P-Bb-ComponentModel-DataAnnotations-ListItem-Name'></a>
### Name `property`

##### Summary

Gets or sets the name. (it is the key)

<a name='P-Bb-ComponentModel-DataAnnotations-ListItem-Selected'></a>
### Selected `property`

##### Summary

Gets or sets the item is selected.

<a name='P-Bb-ComponentModel-DataAnnotations-ListItem-Source'></a>
### Source `property`

##### Summary

Gets the source Provider that generated the current item.

<a name='P-Bb-ComponentModel-DataAnnotations-ListItem-Value'></a>
### Value `property`

##### Summary

Gets or sets the value.

<a name='M-Bb-ComponentModel-DataAnnotations-ListItem-Compare-System-Object-'></a>
### Compare(right) `method`

##### Summary

return true if the value is equal to the value of the object

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| right | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') |  |

<a name='M-Bb-ComponentModel-DataAnnotations-ListItem-Equals-System-Object-'></a>
### Equals(o) `method`

##### Summary

return true if the value is equal to the value of the object

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| o | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') |  |

<a name='M-Bb-ComponentModel-DataAnnotations-ListItem-GetHashCode'></a>
### GetHashCode() `method`

##### Summary

return the hash code of the value

##### Returns



##### Parameters

This method has no parameters.

<a name='M-Bb-ComponentModel-DataAnnotations-ListItem-GetOriginalValue'></a>
### GetOriginalValue() `method`

##### Summary

Return the new value that can be set in the property

##### Returns



##### Parameters

This method has no parameters.

<a name='M-Bb-ComponentModel-DataAnnotations-ListItem-ToString'></a>
### ToString() `method`

##### Summary

Gets or sets the string display

##### Returns



##### Parameters

This method has no parameters.

<a name='T-Bb-ComponentModel-DataAnnotations-ListItem`1'></a>
## ListItem\`1 `type`

##### Namespace

Bb.ComponentModel.DataAnnotations

##### Summary

Represents an item of list.

<a name='P-Bb-ComponentModel-DataAnnotations-ListItem`1-Tag'></a>
### Tag `property`

##### Summary

Gets or sets the value.

<a name='T-Bb-ComponentModel-Attributes-ListProviderAttribute'></a>
## ListProviderAttribute `type`

##### Namespace

Bb.ComponentModel.Attributes

<a name='M-Bb-ComponentModel-Attributes-ListProviderAttribute-#ctor-System-Type-'></a>
### #ctor(typeListResolver,property,instance) `constructor`

##### Summary

new instance of [ListProviderAttribute](#T-Bb-ComponentModel-Attributes-ListProviderAttribute 'Bb.ComponentModel.Attributes.ListProviderAttribute')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| typeListResolver | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | the type must implement [IListProvider](#T-Bb-ComponentModel-DataAnnotations-IListProvider 'Bb.ComponentModel.DataAnnotations.IListProvider') |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException 'System.ArgumentException') | if the type not implement [IListProvider](#T-Bb-ComponentModel-DataAnnotations-IListProvider 'Bb.ComponentModel.DataAnnotations.IListProvider') |

<a name='M-Bb-ComponentModel-Attributes-ListProviderAttribute-GetProvider-System-ComponentModel-PropertyDescriptor,System-Object-'></a>
### GetProvider() `method`

##### Summary

Return the instance of the list provider

##### Returns



##### Parameters

This method has no parameters.

<a name='M-Bb-ComponentModel-Attributes-ListProviderAttribute-GetProvider-System-IServiceProvider,System-ComponentModel-PropertyDescriptor,System-Object-'></a>
### GetProvider(provider,property,instance) `method`

##### Summary

Return the instance of the list provider

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| provider | [System.IServiceProvider](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IServiceProvider 'System.IServiceProvider') | service provider for resolve the type |
| property | [System.ComponentModel.PropertyDescriptor](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ComponentModel.PropertyDescriptor 'System.ComponentModel.PropertyDescriptor') | property descriptor that decorated with the current attribute |
| instance | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | Instance of the object |

<a name='T-Bb-ComponentModel-Attributes-MetaPropertyAttribute'></a>
## MetaPropertyAttribute `type`

##### Namespace

Bb.ComponentModel.Attributes

##### Summary

Meta property attribute

<a name='M-Bb-ComponentModel-Attributes-MetaPropertyAttribute-#ctor-System-String,System-String,System-Object-'></a>
### #ctor(context,name,value) `constructor`

##### Summary

Constructor that create a new [MetaPropertyAttribute](#T-Bb-ComponentModel-Attributes-MetaPropertyAttribute 'Bb.ComponentModel.Attributes.MetaPropertyAttribute')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| context | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | context using |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | name of the property |
| value | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | Value property |

<a name='P-Bb-ComponentModel-Attributes-MetaPropertyAttribute-Context'></a>
### Context `property`

##### Summary

Context of the property

<a name='P-Bb-ComponentModel-Attributes-MetaPropertyAttribute-Name'></a>
### Name `property`

##### Summary

Name of the meta property

<a name='P-Bb-ComponentModel-Attributes-MetaPropertyAttribute-Type'></a>
### Type `property`

##### Summary

Type of the meta property

<a name='P-Bb-ComponentModel-Attributes-MetaPropertyAttribute-Value'></a>
### Value `property`

##### Summary

Value of the meta property

<a name='T-Bb-ComponentModel-Attributes-PriorityHelper'></a>
## PriorityHelper `type`

##### Namespace

Bb.ComponentModel.Attributes

<a name='M-Bb-ComponentModel-Attributes-PriorityHelper-OrderByPriority-System-Collections-Generic-IEnumerable{System-Type}-'></a>
### OrderByPriority(types) `method`

##### Summary

sort the list of type by priority

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| types | [System.Collections.Generic.IEnumerable{System.Type}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{System.Type}') |  |

<a name='T-Bb-ComponentModel-Attributes-ProviderListBase`1'></a>
## ProviderListBase\`1 `type`

##### Namespace

Bb.ComponentModel.Attributes

<a name='P-Bb-ComponentModel-Attributes-ProviderListBase`1-Instance'></a>
### Instance `property`

##### Summary

Instance of the object that contains the property

<a name='P-Bb-ComponentModel-Attributes-ProviderListBase`1-Property'></a>
### Property `property`

##### Summary

Property descriptor

<a name='M-Bb-ComponentModel-Attributes-ProviderListBase`1-CreateItem-`0,System-String,System-Object,System-Action{Bb-ComponentModel-DataAnnotations-ListItem{`0}}-'></a>
### CreateItem(instance) `method`

##### Summary

Create new item

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| instance | [\`0](#T-`0 '`0') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='M-Bb-ComponentModel-Attributes-ProviderListBase`1-GetItems'></a>
### GetItems() `method`

##### Summary

Gets the items list.

##### Returns



##### Parameters

This method has no parameters.

<a name='M-Bb-ComponentModel-Attributes-ProviderListBase`1-ResolveOriginalValue-Bb-ComponentModel-DataAnnotations-ListItem{`0}-'></a>
### ResolveOriginalValue(item) `method`

##### Summary

Return the new value that must to be set in the property

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| item | [Bb.ComponentModel.DataAnnotations.ListItem{\`0}](#T-Bb-ComponentModel-DataAnnotations-ListItem{`0} 'Bb.ComponentModel.DataAnnotations.ListItem{`0}') |  |

<a name='T-Bb-ComponentModel-Translations-TranslatedKeyLabel'></a>
## TranslatedKeyLabel `type`

##### Namespace

Bb.ComponentModel.Translations

##### Summary

"p:path, k:key, l:en-us, d:default value"

<a name='M-Bb-ComponentModel-Translations-TranslatedKeyLabel-#ctor'></a>
### #ctor() `constructor`

##### Summary

Initializes a new instance of the [TranslatedKeyLabel](#T-Bb-ComponentModel-Translations-TranslatedKeyLabel 'Bb.ComponentModel.Translations.TranslatedKeyLabel') class.

##### Parameters

This constructor has no parameters.

<a name='M-Bb-ComponentModel-Translations-TranslatedKeyLabel-#ctor-System-String-'></a>
### #ctor(defaultDisplay) `constructor`

##### Summary

Initializes a new instance of the [TranslatedKeyLabel](#T-Bb-ComponentModel-Translations-TranslatedKeyLabel 'Bb.ComponentModel.Translations.TranslatedKeyLabel') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| defaultDisplay | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | use for create key |

<a name='M-Bb-ComponentModel-Translations-TranslatedKeyLabel-#ctor-System-String,System-String-'></a>
### #ctor(path,defaultDisplay) `constructor`

##### Summary

Initializes a new instance of the [TranslatedKeyLabel](#T-Bb-ComponentModel-Translations-TranslatedKeyLabel 'Bb.ComponentModel.Translations.TranslatedKeyLabel') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| path | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | group of translation key |
| defaultDisplay | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | default display |

<a name='M-Bb-ComponentModel-Translations-TranslatedKeyLabel-#ctor-System-String,System-String,System-String,System-Globalization-CultureInfo-'></a>
### #ctor(path,defaultDisplay,key,culture) `constructor`

##### Summary

Initializes a new instance of the [TranslatedKeyLabel](#T-Bb-ComponentModel-Translations-TranslatedKeyLabel 'Bb.ComponentModel.Translations.TranslatedKeyLabel') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| path | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | context for group key |
| defaultDisplay | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | default display |
| key | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | key of translation |
| culture | [System.Globalization.CultureInfo](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Globalization.CultureInfo 'System.Globalization.CultureInfo') | default culture |

<a name='P-Bb-ComponentModel-Translations-TranslatedKeyLabel-DebugTrace'></a>
### DebugTrace `property`

##### Summary

Intercept failed parsing of key

<a name='P-Bb-ComponentModel-Translations-TranslatedKeyLabel-DefaultCulture'></a>
### DefaultCulture `property`

##### Summary

Default culture

<a name='P-Bb-ComponentModel-Translations-TranslatedKeyLabel-DefaultDisplay'></a>
### DefaultDisplay `property`

##### Summary

Default display

<a name='P-Bb-ComponentModel-Translations-TranslatedKeyLabel-EmptyKey'></a>
### EmptyKey `property`

##### Summary

Default key

<a name='P-Bb-ComponentModel-Translations-TranslatedKeyLabel-IsNotValidKey'></a>
### IsNotValidKey `property`

##### Summary

Return true if the key is not valid

<a name='P-Bb-ComponentModel-Translations-TranslatedKeyLabel-Item-System-Globalization-CultureInfo-'></a>
### Item `property`

##### Summary

return a translation for a culture

##### Returns

[DataTranslation](#T-Bb-ComponentModel-Translations-DataTranslation 'Bb.ComponentModel.Translations.DataTranslation')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| culture | [System.Globalization.CultureInfo](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Globalization.CultureInfo 'System.Globalization.CultureInfo') | asked culture |

<a name='P-Bb-ComponentModel-Translations-TranslatedKeyLabel-Key'></a>
### Key `property`

##### Summary

Translation key

<a name='P-Bb-ComponentModel-Translations-TranslatedKeyLabel-ModeDebug'></a>
### ModeDebug `property`

##### Summary

If true the invalid keys can be intercepted with DebugTrace method

<a name='P-Bb-ComponentModel-Translations-TranslatedKeyLabel-Path'></a>
### Path `property`

##### Summary

Contract of the translation key

<a name='P-Bb-ComponentModel-Translations-TranslatedKeyLabel-Translations'></a>
### Translations `property`

##### Summary

Other translation

<a name='M-Bb-ComponentModel-Translations-TranslatedKeyLabel-Equals-System-Object-'></a>
### Equals(obj) `method`

##### Summary

Evaluate to key

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| obj | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') |  |

<a name='M-Bb-ComponentModel-Translations-TranslatedKeyLabel-IsValid-System-String-'></a>
### IsValid(key) `method`

##### Summary

Evaluate if the key is valid

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| key | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-Bb-ComponentModel-Translations-TranslatedKeyLabel-Parse-System-String-'></a>
### Parse(key) `method`

##### Summary

Parse a key

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| key | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-Bb-ComponentModel-Translations-TranslatedKeyLabel-ToString'></a>
### ToString() `method`

##### Summary

return a valid translation key for the current instance

##### Returns



##### Parameters

This method has no parameters.

<a name='M-Bb-ComponentModel-Translations-TranslatedKeyLabel-Translate-Bb-ComponentModel-Translations-ITranslateHost,Bb-ComponentModel-Translations-TranslatedKeyLabel[]-'></a>
### Translate(service,arguments) `method`

##### Summary

Translate the current key

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| service | [Bb.ComponentModel.Translations.ITranslateHost](#T-Bb-ComponentModel-Translations-ITranslateHost 'Bb.ComponentModel.Translations.ITranslateHost') | service that translate keys |
| arguments | [Bb.ComponentModel.Translations.TranslatedKeyLabel[]](#T-Bb-ComponentModel-Translations-TranslatedKeyLabel[] 'Bb.ComponentModel.Translations.TranslatedKeyLabel[]') | translation keys arguments. (if the result of the translation contains "{\d}", a String.Format is apply with specified arguments |

##### Example

"Do you want to delete item {0}"

<a name='M-Bb-ComponentModel-Translations-TranslatedKeyLabel-Translate-Bb-ComponentModel-Translations-ITranslateService,Bb-ComponentModel-Translations-TranslatedKeyLabel[]-'></a>
### Translate(service,arguments) `method`

##### Summary

Translate the current key

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| service | [Bb.ComponentModel.Translations.ITranslateService](#T-Bb-ComponentModel-Translations-ITranslateService 'Bb.ComponentModel.Translations.ITranslateService') |  |
| arguments | [Bb.ComponentModel.Translations.TranslatedKeyLabel[]](#T-Bb-ComponentModel-Translations-TranslatedKeyLabel[] 'Bb.ComponentModel.Translations.TranslatedKeyLabel[]') | translation keys arguments. (if the result of the translation contains "{\d}", a String.Format is apply with specified arguments |

##### Example

"Do you want to delete item {0}"

<a name='M-Bb-ComponentModel-Translations-TranslatedKeyLabel-TryConvert-System-String,Bb-ComponentModel-Translations-TranslatedKeyLabel@-'></a>
### TryConvert(key,keyLabel) `method`

##### Summary

Try to convert text in translation key

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| key | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| keyLabel | [Bb.ComponentModel.Translations.TranslatedKeyLabel@](#T-Bb-ComponentModel-Translations-TranslatedKeyLabel@ 'Bb.ComponentModel.Translations.TranslatedKeyLabel@') |  |

<a name='T-Bb-ComponentModel-Translations-TranslatedKeyLabelExtension'></a>
## TranslatedKeyLabelExtension `type`

##### Namespace

Bb.ComponentModel.Translations

<a name='M-Bb-ComponentModel-Translations-TranslatedKeyLabelExtension-GetFrom-System-Reflection-MemberInfo-'></a>
### GetFrom(info) `method`

##### Summary

Return the translation of the key if the member contains [TranslationKeyAttribute](#T-Bb-ComponentModel-Attributes-TranslationKeyAttribute 'Bb.ComponentModel.Attributes.TranslationKeyAttribute')

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| info | [System.Reflection.MemberInfo](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.MemberInfo 'System.Reflection.MemberInfo') |  |

<a name='M-Bb-ComponentModel-Translations-TranslatedKeyLabelExtension-IsValidTranslationKey-System-String-'></a>
### IsValidTranslationKey(self) `method`

##### Summary

return true if the key is a valid translation key

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-Bb-ComponentModel-Translations-TranslatedKeyLabelExtension-TryConvertInTranslationKey-System-String,Bb-ComponentModel-Translations-TranslatedKeyLabel@-'></a>
### TryConvertInTranslationKey(self,key) `method`

##### Summary

return true if the key is a valid translation key

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| key | [Bb.ComponentModel.Translations.TranslatedKeyLabel@](#T-Bb-ComponentModel-Translations-TranslatedKeyLabel@ 'Bb.ComponentModel.Translations.TranslatedKeyLabel@') |  |

<a name='T-Bb-ComponentModel-Attributes-TranslationKeyAttribute'></a>
## TranslationKeyAttribute `type`

##### Namespace

Bb.ComponentModel.Attributes

<a name='M-Bb-ComponentModel-Attributes-TranslationKeyAttribute-#ctor-System-String-'></a>
### #ctor(translationKey) `constructor`

##### Summary

Constructor that create a new [TranslationKeyAttribute](#T-Bb-ComponentModel-Attributes-TranslationKeyAttribute 'Bb.ComponentModel.Attributes.TranslationKeyAttribute')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| translationKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-Bb-ComponentModel-Attributes-TranslationKeyAttribute-#ctor-System-String,System-String-'></a>
### #ctor(context,translationKey) `constructor`

##### Summary



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| context | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Context of translation |
| translationKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='P-Bb-ComponentModel-Attributes-TranslationKeyAttribute-Context'></a>
### Context `property`

##### Summary

Context of translation

<a name='P-Bb-ComponentModel-Attributes-TranslationKeyAttribute-Key'></a>
### Key `property`

##### Summary

Translation key

<a name='T-Bb-ComponentModel-TypeDescriptorExtension'></a>
## TypeDescriptorExtension `type`

##### Namespace

Bb.ComponentModel

<a name='M-Bb-ComponentModel-TypeDescriptorExtension-GetProperties-System-Type-'></a>
### GetProperties(self) `method`

##### Summary

Return the list of propertyDescriptors

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') |  |

<a name='M-Bb-ComponentModel-TypeDescriptorExtension-GetProperties-System-Type,System-Func{System-ComponentModel-PropertyDescriptor,System-Boolean}-'></a>
### GetProperties(self,funcFilter) `method`

##### Summary

Return the list of propertyDescriptors

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') |  |
| funcFilter | [System.Func{System.ComponentModel.PropertyDescriptor,System.Boolean}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.ComponentModel.PropertyDescriptor,System.Boolean}') |  |
