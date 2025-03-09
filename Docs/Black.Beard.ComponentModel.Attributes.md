<a name='assembly'></a>
# Black.Beard.ComponentModel.Attributes

## Contents

- [BusySession](#T-Bb-BusySession 'Bb.BusySession')
  - [#ctor(parent,parentInstance)](#M-Bb-BusySession-#ctor-Bb-IBusyService,System-String,System-Object,System-Action{Bb-BusySession}- 'Bb.BusySession.#ctor(Bb.IBusyService,System.String,System.Object,System.Action{Bb.BusySession})')
  - [BusyStatus](#P-Bb-BusySession-BusyStatus 'Bb.BusySession.BusyStatus')
  - [Instance](#P-Bb-BusySession-Instance 'Bb.BusySession.Instance')
  - [Message](#P-Bb-BusySession-Message 'Bb.BusySession.Message')
  - [ProgressPercent](#P-Bb-BusySession-ProgressPercent 'Bb.BusySession.ProgressPercent')
  - [Title](#P-Bb-BusySession-Title 'Bb.BusySession.Title')
  - [Add(action)](#M-Bb-BusySession-Add-System-Action{Bb-BusySession}- 'Bb.BusySession.Add(System.Action{Bb.BusySession})')
  - [Close()](#M-Bb-BusySession-Close 'Bb.BusySession.Close')
  - [Dispose()](#M-Bb-BusySession-Dispose 'Bb.BusySession.Dispose')
  - [Run()](#M-Bb-BusySession-Run 'Bb.BusySession.Run')
  - [Update(message,percent)](#M-Bb-BusySession-Update-System-String,System-Int32- 'Bb.BusySession.Update(System.String,System.Int32)')
- [ConstantsCore](#T-Bb-ComponentModel-ConstantsCore 'Bb.ComponentModel.ConstantsCore')
  - [Cast](#F-Bb-ComponentModel-ConstantsCore-Cast 'Bb.ComponentModel.ConstantsCore.Cast')
  - [Configuration](#F-Bb-ComponentModel-ConstantsCore-Configuration 'Bb.ComponentModel.ConstantsCore.Configuration')
  - [ExposedTypes](#F-Bb-ComponentModel-ConstantsCore-ExposedTypes 'Bb.ComponentModel.ConstantsCore.ExposedTypes')
  - [Initialization](#F-Bb-ComponentModel-ConstantsCore-Initialization 'Bb.ComponentModel.ConstantsCore.Initialization')
  - [Model](#F-Bb-ComponentModel-ConstantsCore-Model 'Bb.ComponentModel.ConstantsCore.Model')
  - [PerfMon](#F-Bb-ComponentModel-ConstantsCore-PerfMon 'Bb.ComponentModel.ConstantsCore.PerfMon')
  - [Plugin](#F-Bb-ComponentModel-ConstantsCore-Plugin 'Bb.ComponentModel.ConstantsCore.Plugin')
  - [Service](#F-Bb-ComponentModel-ConstantsCore-Service 'Bb.ComponentModel.ConstantsCore.Service')
- [CultureProviderList](#T-Bb-ComponentModel-Attributes-CultureProviderList 'Bb.ComponentModel.Attributes.CultureProviderList')
  - [GetItems()](#M-Bb-ComponentModel-Attributes-CultureProviderList-GetItems 'Bb.ComponentModel.Attributes.CultureProviderList.GetItems')
- [DependOfAttribute](#T-Bb-ComponentModel-Attributes-DependOfAttribute 'Bb.ComponentModel.Attributes.DependOfAttribute')
  - [#ctor(type)](#M-Bb-ComponentModel-Attributes-DependOfAttribute-#ctor-System-Type- 'Bb.ComponentModel.Attributes.DependOfAttribute.#ctor(System.Type)')
- [DisposedEventHandler](#T-Bb-ComponentModel-DisposedEventHandler 'Bb.ComponentModel.DisposedEventHandler')
- [EnumerationProviderAttribute](#T-Bb-ComponentModel-Attributes-EnumerationProviderAttribute 'Bb.ComponentModel.Attributes.EnumerationProviderAttribute')
- [EvaluatorEventArgs\`1](#T-Bb-EvaluatorEventArgs`1 'Bb.EvaluatorEventArgs`1')
  - [#ctor(evaluator)](#M-Bb-EvaluatorEventArgs`1-#ctor-System-Func{`0,System-Object,System-Boolean},System-Action{`0,System-Object}- 'Bb.EvaluatorEventArgs`1.#ctor(System.Func{`0,System.Object,System.Boolean},System.Action{`0,System.Object})')
  - [Evaluate(target,value)](#M-Bb-EvaluatorEventArgs`1-Evaluate-`0,System-Object- 'Bb.EvaluatorEventArgs`1.Evaluate(`0,System.Object)')
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
  - [IsBusyFor(instance,title,action)](#M-Bb-IBusyService-IsBusyFor-System-Object,System-String,System-Action{Bb-BusySession}- 'Bb.IBusyService.IsBusyFor(System.Object,System.String,System.Action{Bb.BusySession})')
  - [Update(session)](#M-Bb-IBusyService-Update-Bb-BusySession- 'Bb.IBusyService.Update(Bb.BusySession)')
- [IDisposed](#T-Bb-ComponentModel-IDisposed 'Bb.ComponentModel.IDisposed')
- [IFocusedService\`1](#T-Bb-IFocusedService`1 'Bb.IFocusedService`1')
  - [FocusChange(sender,test)](#M-Bb-IFocusedService`1-FocusChange-System-Object,System-Func{`0,System-Object,System-Boolean}- 'Bb.IFocusedService`1.FocusChange(System.Object,System.Func{`0,System.Object,System.Boolean})')
  - [FocusChange(sender,test,action)](#M-Bb-IFocusedService`1-FocusChange-System-Object,System-Func{`0,System-Object,System-Boolean},System-Action{`0,System-Object}- 'Bb.IFocusedService`1.FocusChange(System.Object,System.Func{`0,System.Object,System.Boolean},System.Action{`0,System.Object})')
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
- [IProjectedService\`1](#T-Bb-IProjectedService`1 'Bb.IProjectedService`1')
  - [FocusChange(sender,test)](#M-Bb-IProjectedService`1-FocusChange-System-Object,System-Func{`0,System-Object,System-Boolean}- 'Bb.IProjectedService`1.FocusChange(System.Object,System.Func{`0,System.Object,System.Boolean})')
- [IUIComponent](#T-Bb-ComponentModel-IUIComponent 'Bb.ComponentModel.IUIComponent')
  - [GetService(type)](#M-Bb-ComponentModel-IUIComponent-GetService-System-Type- 'Bb.ComponentModel.IUIComponent.GetService(System.Type)')
- [IUISite](#T-Bb-ComponentModel-IUISite 'Bb.ComponentModel.IUISite')
  - [Parent](#P-Bb-ComponentModel-IUISite-Parent 'Bb.ComponentModel.IUISite.Parent')
- [InjectBuilder](#T-Bb-ComponentModel-InjectBuilder 'Bb.ComponentModel.InjectBuilder')
  - [FilterToLaunch](#F-Bb-ComponentModel-InjectBuilder-FilterToLaunch 'Bb.ComponentModel.InjectBuilder.FilterToLaunch')
  - [FriendlyName](#P-Bb-ComponentModel-InjectBuilder-FriendlyName 'Bb.ComponentModel.InjectBuilder.FriendlyName')
  - [Type](#P-Bb-ComponentModel-InjectBuilder-Type 'Bb.ComponentModel.InjectBuilder.Type')
  - [CanExecute(context)](#M-Bb-ComponentModel-InjectBuilder-CanExecute-System-Object- 'Bb.ComponentModel.InjectBuilder.CanExecute(System.Object)')
  - [Execute(context)](#M-Bb-ComponentModel-InjectBuilder-Execute-System-Object- 'Bb.ComponentModel.InjectBuilder.Execute(System.Object)')
  - [InitializeExcludedFromEnvironment(key)](#M-Bb-ComponentModel-InjectBuilder-InitializeExcludedFromEnvironment-System-String- 'Bb.ComponentModel.InjectBuilder.InitializeExcludedFromEnvironment(System.String)')
  - [Set(friendlyName,toLaunch)](#M-Bb-ComponentModel-InjectBuilder-Set-System-String,System-Boolean- 'Bb.ComponentModel.InjectBuilder.Set(System.String,System.Boolean)')
  - [ToInjectBuilder(builder)](#M-Bb-ComponentModel-InjectBuilder-ToInjectBuilder-Bb-ComponentModel-IInjectBuilder- 'Bb.ComponentModel.InjectBuilder.ToInjectBuilder(Bb.ComponentModel.IInjectBuilder)')
- [InjectBuilder\`1](#T-Bb-ComponentModel-InjectBuilder`1 'Bb.ComponentModel.InjectBuilder`1')
  - [Type](#P-Bb-ComponentModel-InjectBuilder`1-Type 'Bb.ComponentModel.InjectBuilder`1.Type')
  - [CanExecute(context)](#M-Bb-ComponentModel-InjectBuilder`1-CanExecute-`0- 'Bb.ComponentModel.InjectBuilder`1.CanExecute(`0)')
  - [CanExecute(context)](#M-Bb-ComponentModel-InjectBuilder`1-CanExecute-System-Object- 'Bb.ComponentModel.InjectBuilder`1.CanExecute(System.Object)')
  - [Execute(context)](#M-Bb-ComponentModel-InjectBuilder`1-Execute-System-Object- 'Bb.ComponentModel.InjectBuilder`1.Execute(System.Object)')
  - [Execute(context)](#M-Bb-ComponentModel-InjectBuilder`1-Execute-`0- 'Bb.ComponentModel.InjectBuilder`1.Execute(`0)')
- [InjectValueByIocAttribute](#T-Bb-ComponentModel-Attributes-InjectValueByIocAttribute 'Bb.ComponentModel.Attributes.InjectValueByIocAttribute')
  - [#ctor(variableName,required)](#M-Bb-ComponentModel-Attributes-InjectValueByIocAttribute-#ctor-System-String,System-Boolean- 'Bb.ComponentModel.Attributes.InjectValueByIocAttribute.#ctor(System.String,System.Boolean)')
  - [Required](#P-Bb-ComponentModel-Attributes-InjectValueByIocAttribute-Required 'Bb.ComponentModel.Attributes.InjectValueByIocAttribute.Required')
  - [VariableName](#P-Bb-ComponentModel-Attributes-InjectValueByIocAttribute-VariableName 'Bb.ComponentModel.Attributes.InjectValueByIocAttribute.VariableName')
- [InjectorPolicyAttribute](#T-Bb-ComponentModel-Attributes-InjectorPolicyAttribute 'Bb.ComponentModel.Attributes.InjectorPolicyAttribute')
  - [#ctor(type,lifeCycle)](#M-Bb-ComponentModel-Attributes-InjectorPolicyAttribute-#ctor-System-Type,Bb-ComponentModel-Attributes-IocScopeEnum- 'Bb.ComponentModel.Attributes.InjectorPolicyAttribute.#ctor(System.Type,Bb.ComponentModel.Attributes.IocScopeEnum)')
  - [LifeCycle](#P-Bb-ComponentModel-Attributes-InjectorPolicyAttribute-LifeCycle 'Bb.ComponentModel.Attributes.InjectorPolicyAttribute.LifeCycle')
  - [Type](#P-Bb-ComponentModel-Attributes-InjectorPolicyAttribute-Type 'Bb.ComponentModel.Attributes.InjectorPolicyAttribute.Type')
- [IocConstructorAttribute](#T-Bb-ComponentModel-Attributes-IocConstructorAttribute 'Bb.ComponentModel.Attributes.IocConstructorAttribute')
  - [#ctor()](#M-Bb-ComponentModel-Attributes-IocConstructorAttribute-#ctor 'Bb.ComponentModel.Attributes.IocConstructorAttribute.#ctor')
  - [#ctor()](#M-Bb-ComponentModel-Attributes-IocConstructorAttribute-#ctor-System-Type- 'Bb.ComponentModel.Attributes.IocConstructorAttribute.#ctor(System.Type)')
  - [Type](#P-Bb-ComponentModel-Attributes-IocConstructorAttribute-Type 'Bb.ComponentModel.Attributes.IocConstructorAttribute.Type')
  - [GetMethods(type)](#M-Bb-ComponentModel-Attributes-IocConstructorAttribute-GetMethods-System-Type- 'Bb.ComponentModel.Attributes.IocConstructorAttribute.GetMethods(System.Type)')
- [IocException](#T-Bb-ComponentModel-Exceptions-IocException 'Bb.ComponentModel.Exceptions.IocException')
  - [#ctor()](#M-Bb-ComponentModel-Exceptions-IocException-#ctor 'Bb.ComponentModel.Exceptions.IocException.#ctor')
  - [#ctor(message)](#M-Bb-ComponentModel-Exceptions-IocException-#ctor-System-String- 'Bb.ComponentModel.Exceptions.IocException.#ctor(System.String)')
  - [#ctor(message,inner)](#M-Bb-ComponentModel-Exceptions-IocException-#ctor-System-String,System-Exception- 'Bb.ComponentModel.Exceptions.IocException.#ctor(System.String,System.Exception)')
  - [#ctor(info,context)](#M-Bb-ComponentModel-Exceptions-IocException-#ctor-System-Runtime-Serialization-SerializationInfo,System-Runtime-Serialization-StreamingContext- 'Bb.ComponentModel.Exceptions.IocException.#ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)')
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
- [TypeDescriptorExtension](#T-Bb-ComponentModel-TypeDescriptorExtension 'Bb.ComponentModel.TypeDescriptorExtension')
  - [GetProperties(self)](#M-Bb-ComponentModel-TypeDescriptorExtension-GetProperties-System-Type- 'Bb.ComponentModel.TypeDescriptorExtension.GetProperties(System.Type)')
  - [GetProperties(self,funcFilter)](#M-Bb-ComponentModel-TypeDescriptorExtension-GetProperties-System-Type,System-Func{System-ComponentModel-PropertyDescriptor,System-Boolean}- 'Bb.ComponentModel.TypeDescriptorExtension.GetProperties(System.Type,System.Func{System.ComponentModel.PropertyDescriptor,System.Boolean})')
- [UndefinedException](#T-Bb-ComponentModel-Exceptions-UndefinedException 'Bb.ComponentModel.Exceptions.UndefinedException')
  - [#ctor()](#M-Bb-ComponentModel-Exceptions-UndefinedException-#ctor 'Bb.ComponentModel.Exceptions.UndefinedException.#ctor')
  - [#ctor(variableName)](#M-Bb-ComponentModel-Exceptions-UndefinedException-#ctor-System-String- 'Bb.ComponentModel.Exceptions.UndefinedException.#ctor(System.String)')
  - [#ctor(message,inner)](#M-Bb-ComponentModel-Exceptions-UndefinedException-#ctor-System-String,System-Exception- 'Bb.ComponentModel.Exceptions.UndefinedException.#ctor(System.String,System.Exception)')
  - [#ctor(info,context)](#M-Bb-ComponentModel-Exceptions-UndefinedException-#ctor-System-Runtime-Serialization-SerializationInfo,System-Runtime-Serialization-StreamingContext- 'Bb.ComponentModel.Exceptions.UndefinedException.#ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)')

<a name='T-Bb-BusySession'></a>
## BusySession `type`

##### Namespace

Bb

<a name='M-Bb-BusySession-#ctor-Bb-IBusyService,System-String,System-Object,System-Action{Bb-BusySession}-'></a>
### #ctor(parent,parentInstance) `constructor`

##### Summary

Initialize a new busy session

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| parent | [Bb.IBusyService](#T-Bb-IBusyService 'Bb.IBusyService') |  |
| parentInstance | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='P-Bb-BusySession-BusyStatus'></a>
### BusyStatus `property`

##### Summary

Status of the busy session

<a name='P-Bb-BusySession-Instance'></a>
### Instance `property`

##### Summary

Instance processed in the session

<a name='P-Bb-BusySession-Message'></a>
### Message `property`

##### Summary

Current message of the busy session

<a name='P-Bb-BusySession-ProgressPercent'></a>
### ProgressPercent `property`

##### Summary

Progress percent of the session

<a name='P-Bb-BusySession-Title'></a>
### Title `property`

##### Summary

Title of the session

<a name='M-Bb-BusySession-Add-System-Action{Bb-BusySession}-'></a>
### Add(action) `method`

##### Summary

Append a new action to execute

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| action | [System.Action{Bb.BusySession}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{Bb.BusySession}') |  |

<a name='M-Bb-BusySession-Close'></a>
### Close() `method`

##### Summary

Close the session

##### Returns



##### Parameters

This method has no parameters.

<a name='M-Bb-BusySession-Dispose'></a>
### Dispose() `method`

##### Summary

Dispose the session

##### Parameters

This method has no parameters.

<a name='M-Bb-BusySession-Run'></a>
### Run() `method`

##### Summary

Run the session

##### Returns



##### Parameters

This method has no parameters.

<a name='M-Bb-BusySession-Update-System-String,System-Int32-'></a>
### Update(message,percent) `method`

##### Summary

Update the message form busy session

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| message | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| percent | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') |  |

<a name='T-Bb-ComponentModel-ConstantsCore'></a>
## ConstantsCore `type`

##### Namespace

Bb.ComponentModel

##### Summary

Provides constants for the Core component of the Black.Beard.ComponentModel library.

<a name='F-Bb-ComponentModel-ConstantsCore-Cast'></a>
### Cast `constants`

##### Summary

Gets the name of the cast key for the component.

##### Remarks

This key is used to specify the cast logic for the component.

<a name='F-Bb-ComponentModel-ConstantsCore-Configuration'></a>
### Configuration `constants`

##### Summary

Gets the name of the configuration key for the component.

##### Remarks

This key is used to specify the configuration settings for the component.

<a name='F-Bb-ComponentModel-ConstantsCore-ExposedTypes'></a>
### ExposedTypes `constants`

##### Summary

Gets the name of the exposed types configuration key.

##### Remarks

This key is used to specify the types that should be exposed by the component.

<a name='F-Bb-ComponentModel-ConstantsCore-Initialization'></a>
### Initialization `constants`

##### Summary

Gets the name of the initialization key for the component.

##### Remarks

This key is used to specify the initialization logic for the component.

<a name='F-Bb-ComponentModel-ConstantsCore-Model'></a>
### Model `constants`

##### Summary

Gets the name of the model key for the component.

##### Remarks

This key is used to specify the model settings for the component.

<a name='F-Bb-ComponentModel-ConstantsCore-PerfMon'></a>
### PerfMon `constants`

##### Summary

Gets the name of the performance monitoring key for the component.

##### Remarks

This key is used to specify the performance monitoring settings for the component.

<a name='F-Bb-ComponentModel-ConstantsCore-Plugin'></a>
### Plugin `constants`

##### Summary

Gets the name of the plugin key for the component.

##### Remarks

This key is used to specify the plugin settings for the component.

<a name='F-Bb-ComponentModel-ConstantsCore-Service'></a>
### Service `constants`

##### Summary

Gets the name of the service key for the component.

##### Remarks

This key is used to specify the service settings for the component.

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

<a name='T-Bb-ComponentModel-DisposedEventHandler'></a>
## DisposedEventHandler `type`

##### Namespace

Bb.ComponentModel

##### Summary

Represents the method that will handle the disposing of an object.
event raised when instance is disposed.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [T:Bb.ComponentModel.DisposedEventHandler](#T-T-Bb-ComponentModel-DisposedEventHandler 'T:Bb.ComponentModel.DisposedEventHandler') | The source of the event. |

##### Remarks

This delegate represents the method that will be called when an object is being disposed.

<a name='T-Bb-ComponentModel-Attributes-EnumerationProviderAttribute'></a>
## EnumerationProviderAttribute `type`

##### Namespace

Bb.ComponentModel.Attributes

##### Summary

Enumeration provider attribute

<a name='T-Bb-EvaluatorEventArgs`1'></a>
## EvaluatorEventArgs\`1 `type`

##### Namespace

Bb

##### Summary

Event arguments for evaluator

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='M-Bb-EvaluatorEventArgs`1-#ctor-System-Func{`0,System-Object,System-Boolean},System-Action{`0,System-Object}-'></a>
### #ctor(evaluator) `constructor`

##### Summary

Initialize the evaluator event arguments

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| evaluator | [System.Func{\`0,System.Object,System.Boolean}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{`0,System.Object,System.Boolean}') |  |

<a name='M-Bb-EvaluatorEventArgs`1-Evaluate-`0,System-Object-'></a>
### Evaluate(target,value) `method`

##### Summary

Evaluates the target object with the specified value.

##### Returns

True if the evaluation passes or if the evaluator function is null, otherwise false.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| target | [\`0](#T-`0 '`0') | The target object to evaluate. |
| value | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The value to evaluate the target object with. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown when the target object is null. |

##### Remarks

This method evaluates the target object with the specified value using the provided evaluator function.
If the evaluator function is null or returns true, the action function will be invoked with the target object and the value.

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

- [List<ComponentModel.ExposedTypeConfiguration>](#!-List<ComponentModel-ExposedTypeConfiguration> 'List<ComponentModel.ExposedTypeConfiguration>')

<a name='T-Bb-ComponentModel-Loaders-IApplicationBuilderInitializer'></a>
## IApplicationBuilderInitializer `type`

##### Namespace

Bb.ComponentModel.Loaders

##### Summary



<a name='P-Bb-ComponentModel-Loaders-IApplicationBuilderInitializer-Executed'></a>
### Executed `property`

##### Summary

return true if the builder has been Initialized

##### Remarks

This method returns a boolean value indicating whether the builder has been initialized.

<a name='P-Bb-ComponentModel-Loaders-IApplicationBuilderInitializer-FriendlyName'></a>
### FriendlyName `property`

##### Summary

Friendly name of the builder

##### Remarks

This method returns the friendly name of the builder.

<a name='P-Bb-ComponentModel-Loaders-IApplicationBuilderInitializer-OrderPriority'></a>
### OrderPriority `property`

##### Summary

Order of initialization

##### Remarks

This method returns the order to execute in the list of initialization.

<a name='P-Bb-ComponentModel-Loaders-IApplicationBuilderInitializer-Type'></a>
### Type `property`

##### Summary

Return the type of service that should be passed by argument

##### Remarks

This method returns the type of service that should be passed as an argument.

<a name='T-Bb-IBusyService'></a>
## IBusyService `type`

##### Namespace

Bb

##### Summary

Busy service

##### Remarks

This service provides functionality for managing busy sessions.
A busy session represents a period of time during which a specific instance is busy performing an action.
The service allows subscribing to the BusyChanged event to be notified when the busy state changes.

<a name='M-Bb-IBusyService-IsBusyFor-System-Object,System-String,System-Action{Bb-BusySession}-'></a>
### IsBusyFor(instance,title,action) `method`

##### Summary

Checks if the specified instance is busy and executes the specified action if it is not busy.

##### Returns

The busy session associated with the instance.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| instance | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The instance to check for busy state. |
| title | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The title of the busy session. |
| action | [System.Action{Bb.BusySession}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{Bb.BusySession}') | The action to execute if the instance is not busy. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if the instance parameter is null. |

<a name='M-Bb-IBusyService-Update-Bb-BusySession-'></a>
### Update(session) `method`

##### Summary

Updates the specified busy session.

##### Returns

A task representing the asynchronous operation.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| session | [Bb.BusySession](#T-Bb-BusySession 'Bb.BusySession') | The busy session to update. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if the session parameter is null. |

<a name='T-Bb-ComponentModel-IDisposed'></a>
## IDisposed `type`

##### Namespace

Bb.ComponentModel

##### Summary

Represents an object that can be disposed.

<a name='T-Bb-IFocusedService`1'></a>
## IFocusedService\`1 `type`

##### Namespace

Bb

##### Summary

Project the focused object on target object

<a name='M-Bb-IFocusedService`1-FocusChange-System-Object,System-Func{`0,System-Object,System-Boolean}-'></a>
### FocusChange(sender,test) `method`

##### Summary

Project the object on focus

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | object source |
| test | [System.Func{\`0,System.Object,System.Boolean}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{`0,System.Object,System.Boolean}') | Test to evaluate before change the focus |

<a name='M-Bb-IFocusedService`1-FocusChange-System-Object,System-Func{`0,System-Object,System-Boolean},System-Action{`0,System-Object}-'></a>
### FocusChange(sender,test,action) `method`

##### Summary

Project the object on focus

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | object source |
| test | [System.Func{\`0,System.Object,System.Boolean}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{`0,System.Object,System.Boolean}') | Test to evaluate before change the focus |
| action | [System.Action{\`0,System.Object}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{`0,System.Object}') | method to execute |

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

Return true if the process can be ran

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

Return true if the process can be ran

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

<a name='T-Bb-IProjectedService`1'></a>
## IProjectedService\`1 `type`

##### Namespace

Bb

##### Summary

Project the focused object on target object

<a name='M-Bb-IProjectedService`1-FocusChange-System-Object,System-Func{`0,System-Object,System-Boolean}-'></a>
### FocusChange(sender,test) `method`

##### Summary

Project the object on focus

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | object source |
| test | [System.Func{\`0,System.Object,System.Boolean}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{`0,System.Object,System.Boolean}') | Test to evaluate before change the focus |

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

<a name='T-Bb-ComponentModel-InjectBuilder'></a>
## InjectBuilder `type`

##### Namespace

Bb.ComponentModel

##### Summary

Class base that implement default behavior for [IInjectBuilder](#T-Bb-ComponentModel-IInjectBuilder 'Bb.ComponentModel.IInjectBuilder')

<a name='F-Bb-ComponentModel-InjectBuilder-FilterToLaunch'></a>
### FilterToLaunch `constants`

##### Summary

Internal filter to launch the builders

<a name='P-Bb-ComponentModel-InjectBuilder-FriendlyName'></a>
### FriendlyName `property`

##### Summary

Friendly name of the builder. by default it's the namespace + name of the class

<a name='P-Bb-ComponentModel-InjectBuilder-Type'></a>
### Type `property`

##### Summary

Return the type of service that should be passed by argument

<a name='M-Bb-ComponentModel-InjectBuilder-CanExecute-System-Object-'></a>
### CanExecute(context) `method`

##### Summary

Return true if the process can be run

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| context | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | specified context [Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') |

<a name='M-Bb-ComponentModel-InjectBuilder-Execute-System-Object-'></a>
### Execute(context) `method`

##### Summary

Execute the initializing process with [Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object')

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| context | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | specified context [Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') |

<a name='M-Bb-ComponentModel-InjectBuilder-InitializeExcludedFromEnvironment-System-String-'></a>
### InitializeExcludedFromEnvironment(key) `method`

##### Summary

Initializes the excluded items from the environment based on the specified key.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| key | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The key to retrieve the environment variable. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown when the key parameter is null. |

##### Remarks

This method retrieves the value of the environment variable specified by the key parameter. If the value is not null, it splits the value into individual items using ';' as the separator. For each item, if it starts with '-', it adds the item (excluding the '-' character) to the cache. Otherwise, it removes the item from the cache.
e.g. If the value is "friendlyName1;friendlyName2;-friendlyName3", the cache will contain "friendlyName1" and "friendlyName2" and will not contain "friendlyName3".

<a name='M-Bb-ComponentModel-InjectBuilder-Set-System-String,System-Boolean-'></a>
### Set(friendlyName,toLaunch) `method`

##### Summary

Sets the specified friendly name and launch flag.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| friendlyName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The friendly name. |
| toLaunch | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | The launch flag. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown when the friendlyName parameter is null. |

##### Remarks

This method sets the launch flag for the specified friendly name. If the launch flag is true, the friendly name is removed from the cache. If the launch flag is false, the friendly name is added to the cache.

<a name='M-Bb-ComponentModel-InjectBuilder-ToInjectBuilder-Bb-ComponentModel-IInjectBuilder-'></a>
### ToInjectBuilder(builder) `method`

##### Summary

Determines whether the specified builder should be injected into the builder.

##### Returns

`true` if the specified builder should be injected into the builder; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| builder | [Bb.ComponentModel.IInjectBuilder](#T-Bb-ComponentModel-IInjectBuilder 'Bb.ComponentModel.IInjectBuilder') | The builder. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown when the builder parameter is null. |

##### Remarks

This method checks if the specified builder's friendly name is not present in the cache of a item that must not to execute. If the friendly name is not present, it means the builder should be injected into the builder.

<a name='T-Bb-ComponentModel-InjectBuilder`1'></a>
## InjectBuilder\`1 `type`

##### Namespace

Bb.ComponentModel

##### Summary

Class base that implement default behavior for [IInjectBuilder\`1](#T-Bb-ComponentModel-IInjectBuilder`1 'Bb.ComponentModel.IInjectBuilder`1')

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | context of the initialization |

##### Example

Sample add service in the web application
 
 First add a new class that will intercept the service to configure. in this case the WebApplicationBuilder and the WebApplication

```C#
    
    [ExposeClass(ConstantsCore.Initialization, ExposedType = typeof(IInjectBuilder&lt;WebApplicationBuilder&gt;), LifeCycle = IocScopeEnum.Transiant)]
    public class ConfigureWebApplicationBuilder : InjectBuilder&lt;WebApplicationBuilder&gt;
    {
        public object Execute(WebApplicationBuilder context)
        {
            // Add your code here
            return null;
        }
    }
    
    [ExposeClass(ConstantsCore.Initialization, ExposedType = typeof(IInjectBuilder&lt;WebApplication&gt;), LifeCycle = IocScopeEnum.Transiant)]
    public class ConfigureWebApplication : InjectBuilder&lt;WebApplication&gt;
    {
        public object Execute(WebApplication context)
        {
            // Add your code here
            return null;
        }
    }
```

call the builder in the main program

```
 
     // In the main program insert the bloc that create and initialize the WebApplication class
     WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
     builder.Configure(builder.Services.BuildServiceProvider());
     var app = builder.Build();
     app.Configure(app.Services);
     
 
```

exclude the builder from the environment

```
    InjectBuilder.InitializeExcludedFromEnvironment("environmentKey"); 
```

/// 
 exclude the builder from the variable launch

```
    run -friendlyName
```

<a name='P-Bb-ComponentModel-InjectBuilder`1-Type'></a>
### Type `property`

##### Summary

Return the type of service that should be passed by argument

<a name='M-Bb-ComponentModel-InjectBuilder`1-CanExecute-`0-'></a>
### CanExecute(context) `method`

##### Summary

Return true if the process can be ran

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| context | [\`0](#T-`0 '`0') | specified context [](#!-T 'T') |

<a name='M-Bb-ComponentModel-InjectBuilder`1-CanExecute-System-Object-'></a>
### CanExecute(context) `method`

##### Summary

Return true if the process can be run

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| context | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | specified context [Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') |

<a name='M-Bb-ComponentModel-InjectBuilder`1-Execute-System-Object-'></a>
### Execute(context) `method`

##### Summary

Execute the initializing process with [Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object')

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| context | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | specified context [Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') |

<a name='M-Bb-ComponentModel-InjectBuilder`1-Execute-`0-'></a>
### Execute(context) `method`

##### Summary

Execute the initializing process with [](#!-T 'T')

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| context | [\`0](#T-`0 '`0') | specified context [](#!-T 'T') |

<a name='T-Bb-ComponentModel-Attributes-InjectValueByIocAttribute'></a>
## InjectValueByIocAttribute `type`

##### Namespace

Bb.ComponentModel.Attributes

##### Summary

Attribute to inject a value into a property.

<a name='M-Bb-ComponentModel-Attributes-InjectValueByIocAttribute-#ctor-System-String,System-Boolean-'></a>
### #ctor(variableName,required) `constructor`

##### Summary

Initializes a new instance of the [InjectValueByIocAttribute](#T-Bb-ComponentModel-Attributes-InjectValueByIocAttribute 'Bb.ComponentModel.Attributes.InjectValueByIocAttribute') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| variableName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name of the variable to inject. |
| required | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Indicates whether the variable is required. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown when `variableName` is null or empty. |

##### Remarks

This attribute is used to inject a value into a property.
The `variableName` specifies the name of the variable to inject.
The `required` parameter indicates whether the variable is required or not.

<a name='P-Bb-ComponentModel-Attributes-InjectValueByIocAttribute-Required'></a>
### Required `property`

##### Summary

Indicates whether the variable is required.

<a name='P-Bb-ComponentModel-Attributes-InjectValueByIocAttribute-VariableName'></a>
### VariableName `property`

##### Summary

Variable name to inject.

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

<a name='T-Bb-ComponentModel-Attributes-IocConstructorAttribute'></a>
## IocConstructorAttribute `type`

##### Namespace

Bb.ComponentModel.Attributes

##### Summary

specify this class contains method to create object

<a name='M-Bb-ComponentModel-Attributes-IocConstructorAttribute-#ctor'></a>
### #ctor() `constructor`

##### Summary

Initializes a new instance of the [IocConstructorAttribute](#T-Bb-ComponentModel-Attributes-IocConstructorAttribute 'Bb.ComponentModel.Attributes.IocConstructorAttribute') class.

##### Parameters

This constructor has no parameters.

<a name='M-Bb-ComponentModel-Attributes-IocConstructorAttribute-#ctor-System-Type-'></a>
### #ctor() `constructor`

##### Summary

Initializes a new instance of the [IocConstructorAttribute](#T-Bb-ComponentModel-Attributes-IocConstructorAttribute 'Bb.ComponentModel.Attributes.IocConstructorAttribute') class.

##### Parameters

This constructor has no parameters.

<a name='P-Bb-ComponentModel-Attributes-IocConstructorAttribute-Type'></a>
### Type `property`

##### Summary

Type managed by the constructor

<a name='M-Bb-ComponentModel-Attributes-IocConstructorAttribute-GetMethods-System-Type-'></a>
### GetMethods(type) `method`

##### Summary

Return the list of method to create object

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') |  |

<a name='T-Bb-ComponentModel-Exceptions-IocException'></a>
## IocException `type`

##### Namespace

Bb.ComponentModel.Exceptions

##### Summary

Represents an exception that occurs in the IoC container.

##### Remarks

This exception is thrown when there is an error during the resolution or registration of dependencies in the IoC container.

<a name='M-Bb-ComponentModel-Exceptions-IocException-#ctor'></a>
### #ctor() `constructor`

##### Summary

Initializes a new instance of the [IocException](#T-Bb-ComponentModel-Exceptions-IocException 'Bb.ComponentModel.Exceptions.IocException') class.

##### Parameters

This constructor has no parameters.

<a name='M-Bb-ComponentModel-Exceptions-IocException-#ctor-System-String-'></a>
### #ctor(message) `constructor`

##### Summary

Initializes a new instance of the [IocException](#T-Bb-ComponentModel-Exceptions-IocException 'Bb.ComponentModel.Exceptions.IocException') class with a specified error message.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| message | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The error message that explains the reason for the exception. |

<a name='M-Bb-ComponentModel-Exceptions-IocException-#ctor-System-String,System-Exception-'></a>
### #ctor(message,inner) `constructor`

##### Summary

Initializes a new instance of the [IocException](#T-Bb-ComponentModel-Exceptions-IocException 'Bb.ComponentModel.Exceptions.IocException') class with a specified error message and a reference to the inner exception that is the cause of this exception.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| message | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The error message that explains the reason for the exception. |
| inner | [System.Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') | The exception that is the cause of the current exception, or a null reference if no inner exception is specified. |

<a name='M-Bb-ComponentModel-Exceptions-IocException-#ctor-System-Runtime-Serialization-SerializationInfo,System-Runtime-Serialization-StreamingContext-'></a>
### #ctor(info,context) `constructor`

##### Summary

Initializes a new instance of the [IocException](#T-Bb-ComponentModel-Exceptions-IocException 'Bb.ComponentModel.Exceptions.IocException') class with serialized data.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| info | [System.Runtime.Serialization.SerializationInfo](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Runtime.Serialization.SerializationInfo 'System.Runtime.Serialization.SerializationInfo') | The [SerializationInfo](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Runtime.Serialization.SerializationInfo 'System.Runtime.Serialization.SerializationInfo') that holds the serialized object data about the exception being thrown. |
| context | [System.Runtime.Serialization.StreamingContext](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Runtime.Serialization.StreamingContext 'System.Runtime.Serialization.StreamingContext') | The [StreamingContext](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Runtime.Serialization.StreamingContext 'System.Runtime.Serialization.StreamingContext') that contains contextual information about the source or destination. |

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

<a name='T-Bb-ComponentModel-Exceptions-UndefinedException'></a>
## UndefinedException `type`

##### Namespace

Bb.ComponentModel.Exceptions

##### Summary

Represents an exception that is thrown when a variable cannot be resolved.

##### Remarks

This exception is thrown when a variable cannot be resolved in the current context.

<a name='M-Bb-ComponentModel-Exceptions-UndefinedException-#ctor'></a>
### #ctor() `constructor`

##### Summary

Initializes a new instance of the [UndefinedException](#T-Bb-ComponentModel-Exceptions-UndefinedException 'Bb.ComponentModel.Exceptions.UndefinedException') class.

##### Parameters

This constructor has no parameters.

<a name='M-Bb-ComponentModel-Exceptions-UndefinedException-#ctor-System-String-'></a>
### #ctor(variableName) `constructor`

##### Summary

Initializes a new instance of the [UndefinedException](#T-Bb-ComponentModel-Exceptions-UndefinedException 'Bb.ComponentModel.Exceptions.UndefinedException') class with the specified variable name.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| variableName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name of the variable that cannot be resolved. |

<a name='M-Bb-ComponentModel-Exceptions-UndefinedException-#ctor-System-String,System-Exception-'></a>
### #ctor(message,inner) `constructor`

##### Summary

Initializes a new instance of the [UndefinedException](#T-Bb-ComponentModel-Exceptions-UndefinedException 'Bb.ComponentModel.Exceptions.UndefinedException') class with a specified error message and a reference to the inner exception that is the cause of this exception.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| message | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The error message that explains the reason for the exception. |
| inner | [System.Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') | The exception that is the cause of the current exception, or a null reference if no inner exception is specified. |

<a name='M-Bb-ComponentModel-Exceptions-UndefinedException-#ctor-System-Runtime-Serialization-SerializationInfo,System-Runtime-Serialization-StreamingContext-'></a>
### #ctor(info,context) `constructor`

##### Summary

Initializes a new instance of the [UndefinedException](#T-Bb-ComponentModel-Exceptions-UndefinedException 'Bb.ComponentModel.Exceptions.UndefinedException') class with serialized data.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| info | [System.Runtime.Serialization.SerializationInfo](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Runtime.Serialization.SerializationInfo 'System.Runtime.Serialization.SerializationInfo') | The [SerializationInfo](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Runtime.Serialization.SerializationInfo 'System.Runtime.Serialization.SerializationInfo') that holds the serialized object data about the exception being thrown. |
| context | [System.Runtime.Serialization.StreamingContext](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Runtime.Serialization.StreamingContext 'System.Runtime.Serialization.StreamingContext') | The [StreamingContext](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Runtime.Serialization.StreamingContext 'System.Runtime.Serialization.StreamingContext') that contains contextual information about the source or destination. |
