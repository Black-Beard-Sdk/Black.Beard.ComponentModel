<a name='assembly'></a>
# Black.Beard.ComponentModel.Attributes

## Contents

- [Busy](#T-Bb-ComponentModel-Busy 'Bb.ComponentModel.Busy')
  - [Completed](#F-Bb-ComponentModel-Busy-Completed 'Bb.ComponentModel.Busy.Completed')
  - [New](#F-Bb-ComponentModel-Busy-New 'Bb.ComponentModel.Busy.New')
  - [Running](#F-Bb-ComponentModel-Busy-Running 'Bb.ComponentModel.Busy.Running')
  - [Started](#F-Bb-ComponentModel-Busy-Started 'Bb.ComponentModel.Busy.Started')
- [BusyEventArgs](#T-Bb-ComponentModel-BusyEventArgs 'Bb.ComponentModel.BusyEventArgs')
  - [#ctor(source)](#M-Bb-ComponentModel-BusyEventArgs-#ctor-Bb-ComponentModel-BusySession- 'Bb.ComponentModel.BusyEventArgs.#ctor(Bb.ComponentModel.BusySession)')
  - [Source](#P-Bb-ComponentModel-BusyEventArgs-Source 'Bb.ComponentModel.BusyEventArgs.Source')
- [BusySession](#T-Bb-ComponentModel-BusySession 'Bb.ComponentModel.BusySession')
  - [#ctor(parent,title,parentInstance,action)](#M-Bb-ComponentModel-BusySession-#ctor-Bb-ComponentModel-IBusyService,System-String,System-Object,System-Action{Bb-ComponentModel-BusySession}- 'Bb.ComponentModel.BusySession.#ctor(Bb.ComponentModel.IBusyService,System.String,System.Object,System.Action{Bb.ComponentModel.BusySession})')
  - [BusyStatus](#P-Bb-ComponentModel-BusySession-BusyStatus 'Bb.ComponentModel.BusySession.BusyStatus')
  - [Instance](#P-Bb-ComponentModel-BusySession-Instance 'Bb.ComponentModel.BusySession.Instance')
  - [Message](#P-Bb-ComponentModel-BusySession-Message 'Bb.ComponentModel.BusySession.Message')
  - [ProgressPercent](#P-Bb-ComponentModel-BusySession-ProgressPercent 'Bb.ComponentModel.BusySession.ProgressPercent')
  - [Title](#P-Bb-ComponentModel-BusySession-Title 'Bb.ComponentModel.BusySession.Title')
  - [Add(action)](#M-Bb-ComponentModel-BusySession-Add-System-Action{Bb-ComponentModel-BusySession}- 'Bb.ComponentModel.BusySession.Add(System.Action{Bb.ComponentModel.BusySession})')
  - [Close()](#M-Bb-ComponentModel-BusySession-Close 'Bb.ComponentModel.BusySession.Close')
  - [Dispose(disposing)](#M-Bb-ComponentModel-BusySession-Dispose-System-Boolean- 'Bb.ComponentModel.BusySession.Dispose(System.Boolean)')
  - [Dispose()](#M-Bb-ComponentModel-BusySession-Dispose 'Bb.ComponentModel.BusySession.Dispose')
  - [Run()](#M-Bb-ComponentModel-BusySession-Run 'Bb.ComponentModel.BusySession.Run')
  - [Update(message,percent)](#M-Bb-ComponentModel-BusySession-Update-System-String,System-Int32- 'Bb.ComponentModel.BusySession.Update(System.String,System.Int32)')
- [ConfigurationAttribute](#T-Bb-ComponentModel-Attributes-ConfigurationAttribute 'Bb.ComponentModel.Attributes.ConfigurationAttribute')
  - [#ctor()](#M-Bb-ComponentModel-Attributes-ConfigurationAttribute-#ctor 'Bb.ComponentModel.Attributes.ConfigurationAttribute.#ctor')
  - [TypeSerializationToJson](#F-Bb-ComponentModel-Attributes-ConfigurationAttribute-TypeSerializationToJson 'Bb.ComponentModel.Attributes.ConfigurationAttribute.TypeSerializationToJson')
  - [TypeSerializationToXml](#F-Bb-ComponentModel-Attributes-ConfigurationAttribute-TypeSerializationToXml 'Bb.ComponentModel.Attributes.ConfigurationAttribute.TypeSerializationToXml')
  - [TypeSerializationToYml](#F-Bb-ComponentModel-Attributes-ConfigurationAttribute-TypeSerializationToYml 'Bb.ComponentModel.Attributes.ConfigurationAttribute.TypeSerializationToYml')
  - [ConfigurationKey](#P-Bb-ComponentModel-Attributes-ConfigurationAttribute-ConfigurationKey 'Bb.ComponentModel.Attributes.ConfigurationAttribute.ConfigurationKey')
  - [TypeSerialization](#P-Bb-ComponentModel-Attributes-ConfigurationAttribute-TypeSerialization 'Bb.ComponentModel.Attributes.ConfigurationAttribute.TypeSerialization')
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
  - [Type](#P-Bb-ComponentModel-Attributes-DependOfAttribute-Type 'Bb.ComponentModel.Attributes.DependOfAttribute.Type')
- [DisplayOnUITextAreaAttribute](#T-Bb-ComponentModel-Attributes-DisplayOnUITextAreaAttribute 'Bb.ComponentModel.Attributes.DisplayOnUITextAreaAttribute')
  - [#ctor(lines)](#M-Bb-ComponentModel-Attributes-DisplayOnUITextAreaAttribute-#ctor-System-Int32- 'Bb.ComponentModel.Attributes.DisplayOnUITextAreaAttribute.#ctor(System.Int32)')
  - [Lines](#P-Bb-ComponentModel-Attributes-DisplayOnUITextAreaAttribute-Lines 'Bb.ComponentModel.Attributes.DisplayOnUITextAreaAttribute.Lines')
- [EnumerationProviderAttribute](#T-Bb-ComponentModel-Attributes-EnumerationProviderAttribute 'Bb.ComponentModel.Attributes.EnumerationProviderAttribute')
  - [#ctor(typeProvider)](#M-Bb-ComponentModel-Attributes-EnumerationProviderAttribute-#ctor-System-Type- 'Bb.ComponentModel.Attributes.EnumerationProviderAttribute.#ctor(System.Type)')
  - [Provider](#P-Bb-ComponentModel-Attributes-EnumerationProviderAttribute-Provider 'Bb.ComponentModel.Attributes.EnumerationProviderAttribute.Provider')
- [EvaluateValidationAttribute](#T-Bb-ComponentModel-Attributes-EvaluateValidationAttribute 'Bb.ComponentModel.Attributes.EvaluateValidationAttribute')
  - [#ctor(toEvaluate)](#M-Bb-ComponentModel-Attributes-EvaluateValidationAttribute-#ctor-System-Boolean- 'Bb.ComponentModel.Attributes.EvaluateValidationAttribute.#ctor(System.Boolean)')
  - [ToEvaluate](#P-Bb-ComponentModel-Attributes-EvaluateValidationAttribute-ToEvaluate 'Bb.ComponentModel.Attributes.EvaluateValidationAttribute.ToEvaluate')
- [EvaluatorEventArgs\`1](#T-Bb-ComponentModel-EvaluatorEventArgs`1 'Bb.ComponentModel.EvaluatorEventArgs`1')
  - [#ctor(evaluator,action)](#M-Bb-ComponentModel-EvaluatorEventArgs`1-#ctor-System-Func{`0,System-Object,System-Boolean},System-Action{`0,System-Object}- 'Bb.ComponentModel.EvaluatorEventArgs`1.#ctor(System.Func{`0,System.Object,System.Boolean},System.Action{`0,System.Object})')
  - [Evaluate(target,value)](#M-Bb-ComponentModel-EvaluatorEventArgs`1-Evaluate-`0,System-Object- 'Bb.ComponentModel.EvaluatorEventArgs`1.Evaluate(`0,System.Object)')
- [ExposeClassAttribute](#T-Bb-ComponentModel-Attributes-ExposeClassAttribute 'Bb.ComponentModel.Attributes.ExposeClassAttribute')
  - [#ctor()](#M-Bb-ComponentModel-Attributes-ExposeClassAttribute-#ctor 'Bb.ComponentModel.Attributes.ExposeClassAttribute.#ctor')
  - [#ctor(context)](#M-Bb-ComponentModel-Attributes-ExposeClassAttribute-#ctor-System-String- 'Bb.ComponentModel.Attributes.ExposeClassAttribute.#ctor(System.String)')
  - [#ctor(context,display)](#M-Bb-ComponentModel-Attributes-ExposeClassAttribute-#ctor-System-String,System-String- 'Bb.ComponentModel.Attributes.ExposeClassAttribute.#ctor(System.String,System.String)')
  - [Context](#P-Bb-ComponentModel-Attributes-ExposeClassAttribute-Context 'Bb.ComponentModel.Attributes.ExposeClassAttribute.Context')
  - [ExposedType](#P-Bb-ComponentModel-Attributes-ExposeClassAttribute-ExposedType 'Bb.ComponentModel.Attributes.ExposeClassAttribute.ExposedType')
  - [LifeCycle](#P-Bb-ComponentModel-Attributes-ExposeClassAttribute-LifeCycle 'Bb.ComponentModel.Attributes.ExposeClassAttribute.LifeCycle')
  - [Name](#P-Bb-ComponentModel-Attributes-ExposeClassAttribute-Name 'Bb.ComponentModel.Attributes.ExposeClassAttribute.Name')
  - [TypeId](#P-Bb-ComponentModel-Attributes-ExposeClassAttribute-TypeId 'Bb.ComponentModel.Attributes.ExposeClassAttribute.TypeId')
  - [Equals(obj)](#M-Bb-ComponentModel-Attributes-ExposeClassAttribute-Equals-System-Object- 'Bb.ComponentModel.Attributes.ExposeClassAttribute.Equals(System.Object)')
  - [GetHashCode()](#M-Bb-ComponentModel-Attributes-ExposeClassAttribute-GetHashCode 'Bb.ComponentModel.Attributes.ExposeClassAttribute.GetHashCode')
- [ExposeMethodAttribute](#T-Bb-ComponentModel-Attributes-ExposeMethodAttribute 'Bb.ComponentModel.Attributes.ExposeMethodAttribute')
  - [#ctor()](#M-Bb-ComponentModel-Attributes-ExposeMethodAttribute-#ctor 'Bb.ComponentModel.Attributes.ExposeMethodAttribute.#ctor')
  - [#ctor(displayName)](#M-Bb-ComponentModel-Attributes-ExposeMethodAttribute-#ctor-System-String- 'Bb.ComponentModel.Attributes.ExposeMethodAttribute.#ctor(System.String)')
  - [#ctor(context,displayName)](#M-Bb-ComponentModel-Attributes-ExposeMethodAttribute-#ctor-System-String,System-String- 'Bb.ComponentModel.Attributes.ExposeMethodAttribute.#ctor(System.String,System.String)')
  - [#ctor(context,kind,displayName)](#M-Bb-ComponentModel-Attributes-ExposeMethodAttribute-#ctor-System-String,Bb-ComponentModel-Attributes-MethodType,System-String- 'Bb.ComponentModel.Attributes.ExposeMethodAttribute.#ctor(System.String,Bb.ComponentModel.Attributes.MethodType,System.String)')
  - [Context](#P-Bb-ComponentModel-Attributes-ExposeMethodAttribute-Context 'Bb.ComponentModel.Attributes.ExposeMethodAttribute.Context')
  - [DisplayName](#P-Bb-ComponentModel-Attributes-ExposeMethodAttribute-DisplayName 'Bb.ComponentModel.Attributes.ExposeMethodAttribute.DisplayName')
  - [Kind](#P-Bb-ComponentModel-Attributes-ExposeMethodAttribute-Kind 'Bb.ComponentModel.Attributes.ExposeMethodAttribute.Kind')
- [ExposedAttributeTypeConfiguration](#T-Bb-ComponentModel-Attributes-ExposedAttributeTypeConfiguration 'Bb.ComponentModel.Attributes.ExposedAttributeTypeConfiguration')
  - [#ctor()](#M-Bb-ComponentModel-Attributes-ExposedAttributeTypeConfiguration-#ctor 'Bb.ComponentModel.Attributes.ExposedAttributeTypeConfiguration.#ctor')
  - [Context](#P-Bb-ComponentModel-Attributes-ExposedAttributeTypeConfiguration-Context 'Bb.ComponentModel.Attributes.ExposedAttributeTypeConfiguration.Context')
  - [ExposedType](#P-Bb-ComponentModel-Attributes-ExposedAttributeTypeConfiguration-ExposedType 'Bb.ComponentModel.Attributes.ExposedAttributeTypeConfiguration.ExposedType')
  - [LifeCycle](#P-Bb-ComponentModel-Attributes-ExposedAttributeTypeConfiguration-LifeCycle 'Bb.ComponentModel.Attributes.ExposedAttributeTypeConfiguration.LifeCycle')
  - [Name](#P-Bb-ComponentModel-Attributes-ExposedAttributeTypeConfiguration-Name 'Bb.ComponentModel.Attributes.ExposedAttributeTypeConfiguration.Name')
  - [TypeName](#P-Bb-ComponentModel-Attributes-ExposedAttributeTypeConfiguration-TypeName 'Bb.ComponentModel.Attributes.ExposedAttributeTypeConfiguration.TypeName')
- [ExposedTypeConfigurations](#T-Bb-ComponentModel-Attributes-ExposedTypeConfigurations 'Bb.ComponentModel.Attributes.ExposedTypeConfigurations')
- [IApplicationBuilderInitializer](#T-Bb-ComponentModel-IApplicationBuilderInitializer 'Bb.ComponentModel.IApplicationBuilderInitializer')
  - [Executed](#P-Bb-ComponentModel-IApplicationBuilderInitializer-Executed 'Bb.ComponentModel.IApplicationBuilderInitializer.Executed')
  - [FriendlyName](#P-Bb-ComponentModel-IApplicationBuilderInitializer-FriendlyName 'Bb.ComponentModel.IApplicationBuilderInitializer.FriendlyName')
  - [OrderPriority](#P-Bb-ComponentModel-IApplicationBuilderInitializer-OrderPriority 'Bb.ComponentModel.IApplicationBuilderInitializer.OrderPriority')
  - [Type](#P-Bb-ComponentModel-IApplicationBuilderInitializer-Type 'Bb.ComponentModel.IApplicationBuilderInitializer.Type')
- [IBusyService](#T-Bb-ComponentModel-IBusyService 'Bb.ComponentModel.IBusyService')
  - [IsBusyFor(instance,title,action)](#M-Bb-ComponentModel-IBusyService-IsBusyFor-System-Object,System-String,System-Action{Bb-ComponentModel-BusySession}- 'Bb.ComponentModel.IBusyService.IsBusyFor(System.Object,System.String,System.Action{Bb.ComponentModel.BusySession})')
  - [Update(session)](#M-Bb-ComponentModel-IBusyService-Update-Bb-ComponentModel-BusySession- 'Bb.ComponentModel.IBusyService.Update(Bb.ComponentModel.BusySession)')
- [IFocusedService\`1](#T-Bb-ComponentModel-IFocusedService`1 'Bb.ComponentModel.IFocusedService`1')
  - [FocusChange(sender,test)](#M-Bb-ComponentModel-IFocusedService`1-FocusChange-System-Object,System-Func{`0,System-Object,System-Boolean}- 'Bb.ComponentModel.IFocusedService`1.FocusChange(System.Object,System.Func{`0,System.Object,System.Boolean})')
  - [FocusChange(sender,test,action)](#M-Bb-ComponentModel-IFocusedService`1-FocusChange-System-Object,System-Func{`0,System-Object,System-Boolean},System-Action{`0,System-Object}- 'Bb.ComponentModel.IFocusedService`1.FocusChange(System.Object,System.Func{`0,System.Object,System.Boolean},System.Action{`0,System.Object})')
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
  - [Compare(left,right)](#M-Bb-ComponentModel-DataAnnotations-IListProvider-Compare-Bb-ComponentModel-DataAnnotations-ListItem,System-Object- 'Bb.ComponentModel.DataAnnotations.IListProvider.Compare(Bb.ComponentModel.DataAnnotations.ListItem,System.Object)')
  - [GetItems()](#M-Bb-ComponentModel-DataAnnotations-IListProvider-GetItems 'Bb.ComponentModel.DataAnnotations.IListProvider.GetItems')
  - [GetOriginalValue(item)](#M-Bb-ComponentModel-DataAnnotations-IListProvider-GetOriginalValue-Bb-ComponentModel-DataAnnotations-ListItem- 'Bb.ComponentModel.DataAnnotations.IListProvider.GetOriginalValue(Bb.ComponentModel.DataAnnotations.ListItem)')
- [ILogin](#T-Bb-ComponentModel-DataAnnotations-ILogin 'Bb.ComponentModel.DataAnnotations.ILogin')
  - [Login](#P-Bb-ComponentModel-DataAnnotations-ILogin-Login 'Bb.ComponentModel.DataAnnotations.ILogin.Login')
  - [Password](#P-Bb-ComponentModel-DataAnnotations-ILogin-Password 'Bb.ComponentModel.DataAnnotations.ILogin.Password')
- [IProjectedService\`1](#T-Bb-ComponentModel-IProjectedService`1 'Bb.ComponentModel.IProjectedService`1')
  - [Execute(action)](#M-Bb-ComponentModel-IProjectedService`1-Execute-System-Action{`0,System-Object}- 'Bb.ComponentModel.IProjectedService`1.Execute(System.Action{`0,System.Object})')
  - [FocusChange(sender,test)](#M-Bb-ComponentModel-IProjectedService`1-FocusChange-System-Object,System-Func{`0,System-Object,System-Boolean}- 'Bb.ComponentModel.IProjectedService`1.FocusChange(System.Object,System.Func{`0,System.Object,System.Boolean})')
  - [Register(service)](#M-Bb-ComponentModel-IProjectedService`1-Register-`0- 'Bb.ComponentModel.IProjectedService`1.Register(`0)')
- [IRefreshService](#T-Bb-ComponentModel-IRefreshService 'Bb.ComponentModel.IRefreshService')
  - [CallRequestRefresh(sender,toRefresh)](#M-Bb-ComponentModel-IRefreshService-CallRequestRefresh-System-Object,System-Object[]- 'Bb.ComponentModel.IRefreshService.CallRequestRefresh(System.Object,System.Object[])')
- [InjectBuilder](#T-Bb-ComponentModel-InjectBuilder 'Bb.ComponentModel.InjectBuilder')
  - [FilterToLaunch](#P-Bb-ComponentModel-InjectBuilder-FilterToLaunch 'Bb.ComponentModel.InjectBuilder.FilterToLaunch')
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
- [InjectByIocAttribute](#T-Bb-ComponentModel-Attributes-InjectByIocAttribute 'Bb.ComponentModel.Attributes.InjectByIocAttribute')
  - [#ctor()](#M-Bb-ComponentModel-Attributes-InjectByIocAttribute-#ctor 'Bb.ComponentModel.Attributes.InjectByIocAttribute.#ctor')
  - [#ctor(type)](#M-Bb-ComponentModel-Attributes-InjectByIocAttribute-#ctor-System-Type- 'Bb.ComponentModel.Attributes.InjectByIocAttribute.#ctor(System.Type)')
  - [TypeToInject](#P-Bb-ComponentModel-Attributes-InjectByIocAttribute-TypeToInject 'Bb.ComponentModel.Attributes.InjectByIocAttribute.TypeToInject')
- [InjectValueByIocAttribute](#T-Bb-ComponentModel-Attributes-InjectValueByIocAttribute 'Bb.ComponentModel.Attributes.InjectValueByIocAttribute')
  - [#ctor(variableName,required)](#M-Bb-ComponentModel-Attributes-InjectValueByIocAttribute-#ctor-System-String,System-Boolean- 'Bb.ComponentModel.Attributes.InjectValueByIocAttribute.#ctor(System.String,System.Boolean)')
  - [Required](#P-Bb-ComponentModel-Attributes-InjectValueByIocAttribute-Required 'Bb.ComponentModel.Attributes.InjectValueByIocAttribute.Required')
  - [VariableName](#P-Bb-ComponentModel-Attributes-InjectValueByIocAttribute-VariableName 'Bb.ComponentModel.Attributes.InjectValueByIocAttribute.VariableName')
- [InjectorPolicyAttribute](#T-Bb-ComponentModel-Attributes-InjectorPolicyAttribute 'Bb.ComponentModel.Attributes.InjectorPolicyAttribute')
  - [#ctor(type,lifeCycle)](#M-Bb-ComponentModel-Attributes-InjectorPolicyAttribute-#ctor-System-Type,Bb-ComponentModel-Attributes-IocScope- 'Bb.ComponentModel.Attributes.InjectorPolicyAttribute.#ctor(System.Type,Bb.ComponentModel.Attributes.IocScope)')
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
- [IocScope](#T-Bb-ComponentModel-Attributes-IocScope 'Bb.ComponentModel.Attributes.IocScope')
  - [Scoped](#F-Bb-ComponentModel-Attributes-IocScope-Scoped 'Bb.ComponentModel.Attributes.IocScope.Scoped')
  - [Singleton](#F-Bb-ComponentModel-Attributes-IocScope-Singleton 'Bb.ComponentModel.Attributes.IocScope.Singleton')
  - [Transiant](#F-Bb-ComponentModel-Attributes-IocScope-Transiant 'Bb.ComponentModel.Attributes.IocScope.Transiant')
- [ListItem](#T-Bb-ComponentModel-DataAnnotations-ListItem 'Bb.ComponentModel.DataAnnotations.ListItem')
  - [Disabled](#P-Bb-ComponentModel-DataAnnotations-ListItem-Disabled 'Bb.ComponentModel.DataAnnotations.ListItem.Disabled')
  - [Display](#P-Bb-ComponentModel-DataAnnotations-ListItem-Display 'Bb.ComponentModel.DataAnnotations.ListItem.Display')
  - [Icon](#P-Bb-ComponentModel-DataAnnotations-ListItem-Icon 'Bb.ComponentModel.DataAnnotations.ListItem.Icon')
  - [Name](#P-Bb-ComponentModel-DataAnnotations-ListItem-Name 'Bb.ComponentModel.DataAnnotations.ListItem.Name')
  - [Selected](#P-Bb-ComponentModel-DataAnnotations-ListItem-Selected 'Bb.ComponentModel.DataAnnotations.ListItem.Selected')
  - [Source](#P-Bb-ComponentModel-DataAnnotations-ListItem-Source 'Bb.ComponentModel.DataAnnotations.ListItem.Source')
  - [Tag](#P-Bb-ComponentModel-DataAnnotations-ListItem-Tag 'Bb.ComponentModel.DataAnnotations.ListItem.Tag')
  - [Value](#P-Bb-ComponentModel-DataAnnotations-ListItem-Value 'Bb.ComponentModel.DataAnnotations.ListItem.Value')
  - [Compare(right)](#M-Bb-ComponentModel-DataAnnotations-ListItem-Compare-System-Object- 'Bb.ComponentModel.DataAnnotations.ListItem.Compare(System.Object)')
  - [Equals(obj)](#M-Bb-ComponentModel-DataAnnotations-ListItem-Equals-System-Object- 'Bb.ComponentModel.DataAnnotations.ListItem.Equals(System.Object)')
  - [GetHashCode()](#M-Bb-ComponentModel-DataAnnotations-ListItem-GetHashCode 'Bb.ComponentModel.DataAnnotations.ListItem.GetHashCode')
  - [GetOriginalValue()](#M-Bb-ComponentModel-DataAnnotations-ListItem-GetOriginalValue 'Bb.ComponentModel.DataAnnotations.ListItem.GetOriginalValue')
  - [ToString()](#M-Bb-ComponentModel-DataAnnotations-ListItem-ToString 'Bb.ComponentModel.DataAnnotations.ListItem.ToString')
- [ListItem\`1](#T-Bb-ComponentModel-DataAnnotations-ListItem`1 'Bb.ComponentModel.DataAnnotations.ListItem`1')
  - [Tag](#P-Bb-ComponentModel-DataAnnotations-ListItem`1-Tag 'Bb.ComponentModel.DataAnnotations.ListItem`1.Tag')
- [ListProviderAttribute](#T-Bb-ComponentModel-Attributes-ListProviderAttribute 'Bb.ComponentModel.Attributes.ListProviderAttribute')
  - [#ctor(typeListResolver)](#M-Bb-ComponentModel-Attributes-ListProviderAttribute-#ctor-System-Type- 'Bb.ComponentModel.Attributes.ListProviderAttribute.#ctor(System.Type)')
  - [ProviderListType](#P-Bb-ComponentModel-Attributes-ListProviderAttribute-ProviderListType 'Bb.ComponentModel.Attributes.ListProviderAttribute.ProviderListType')
  - [GetProvider()](#M-Bb-ComponentModel-Attributes-ListProviderAttribute-GetProvider-System-ComponentModel-PropertyDescriptor,System-Object- 'Bb.ComponentModel.Attributes.ListProviderAttribute.GetProvider(System.ComponentModel.PropertyDescriptor,System.Object)')
  - [GetProvider(provider,property,instance)](#M-Bb-ComponentModel-Attributes-ListProviderAttribute-GetProvider-System-IServiceProvider,System-ComponentModel-PropertyDescriptor,System-Object- 'Bb.ComponentModel.Attributes.ListProviderAttribute.GetProvider(System.IServiceProvider,System.ComponentModel.PropertyDescriptor,System.Object)')
- [MetaPropertyAttribute](#T-Bb-ComponentModel-Attributes-MetaPropertyAttribute 'Bb.ComponentModel.Attributes.MetaPropertyAttribute')
  - [#ctor(context,name,value)](#M-Bb-ComponentModel-Attributes-MetaPropertyAttribute-#ctor-System-String,System-String,System-Object- 'Bb.ComponentModel.Attributes.MetaPropertyAttribute.#ctor(System.String,System.String,System.Object)')
  - [Context](#P-Bb-ComponentModel-Attributes-MetaPropertyAttribute-Context 'Bb.ComponentModel.Attributes.MetaPropertyAttribute.Context')
  - [Name](#P-Bb-ComponentModel-Attributes-MetaPropertyAttribute-Name 'Bb.ComponentModel.Attributes.MetaPropertyAttribute.Name')
  - [Type](#P-Bb-ComponentModel-Attributes-MetaPropertyAttribute-Type 'Bb.ComponentModel.Attributes.MetaPropertyAttribute.Type')
  - [Value](#P-Bb-ComponentModel-Attributes-MetaPropertyAttribute-Value 'Bb.ComponentModel.Attributes.MetaPropertyAttribute.Value')
- [MethodType](#T-Bb-ComponentModel-Attributes-MethodType 'Bb.ComponentModel.Attributes.MethodType')
  - [Add](#F-Bb-ComponentModel-Attributes-MethodType-Add 'Bb.ComponentModel.Attributes.MethodType.Add')
  - [Del](#F-Bb-ComponentModel-Attributes-MethodType-Del 'Bb.ComponentModel.Attributes.MethodType.Del')
  - [New](#F-Bb-ComponentModel-Attributes-MethodType-New 'Bb.ComponentModel.Attributes.MethodType.New')
  - [Other](#F-Bb-ComponentModel-Attributes-MethodType-Other 'Bb.ComponentModel.Attributes.MethodType.Other')
- [OrderDisplayAttribute](#T-Bb-ComponentModel-Attributes-OrderDisplayAttribute 'Bb.ComponentModel.Attributes.OrderDisplayAttribute')
  - [#ctor(position)](#M-Bb-ComponentModel-Attributes-OrderDisplayAttribute-#ctor-System-Int32- 'Bb.ComponentModel.Attributes.OrderDisplayAttribute.#ctor(System.Int32)')
  - [Position](#P-Bb-ComponentModel-Attributes-OrderDisplayAttribute-Position 'Bb.ComponentModel.Attributes.OrderDisplayAttribute.Position')
- [PriorityAttribute](#T-Bb-ComponentModel-Attributes-PriorityAttribute 'Bb.ComponentModel.Attributes.PriorityAttribute')
  - [#ctor(priority)](#M-Bb-ComponentModel-Attributes-PriorityAttribute-#ctor-System-Int32- 'Bb.ComponentModel.Attributes.PriorityAttribute.#ctor(System.Int32)')
  - [Priority](#P-Bb-ComponentModel-Attributes-PriorityAttribute-Priority 'Bb.ComponentModel.Attributes.PriorityAttribute.Priority')
  - [CompareTo(other)](#M-Bb-ComponentModel-Attributes-PriorityAttribute-CompareTo-Bb-ComponentModel-Attributes-PriorityAttribute- 'Bb.ComponentModel.Attributes.PriorityAttribute.CompareTo(Bb.ComponentModel.Attributes.PriorityAttribute)')
  - [Equals(obj)](#M-Bb-ComponentModel-Attributes-PriorityAttribute-Equals-System-Object- 'Bb.ComponentModel.Attributes.PriorityAttribute.Equals(System.Object)')
  - [GetHashCode()](#M-Bb-ComponentModel-Attributes-PriorityAttribute-GetHashCode 'Bb.ComponentModel.Attributes.PriorityAttribute.GetHashCode')
  - [ResolvePriority(type)](#M-Bb-ComponentModel-Attributes-PriorityAttribute-ResolvePriority-System-Type- 'Bb.ComponentModel.Attributes.PriorityAttribute.ResolvePriority(System.Type)')
  - [op_Equality(left,right)](#M-Bb-ComponentModel-Attributes-PriorityAttribute-op_Equality-Bb-ComponentModel-Attributes-PriorityAttribute,Bb-ComponentModel-Attributes-PriorityAttribute- 'Bb.ComponentModel.Attributes.PriorityAttribute.op_Equality(Bb.ComponentModel.Attributes.PriorityAttribute,Bb.ComponentModel.Attributes.PriorityAttribute)')
  - [op_GreaterThan(left,right)](#M-Bb-ComponentModel-Attributes-PriorityAttribute-op_GreaterThan-Bb-ComponentModel-Attributes-PriorityAttribute,Bb-ComponentModel-Attributes-PriorityAttribute- 'Bb.ComponentModel.Attributes.PriorityAttribute.op_GreaterThan(Bb.ComponentModel.Attributes.PriorityAttribute,Bb.ComponentModel.Attributes.PriorityAttribute)')
  - [op_GreaterThanOrEqual(left,right)](#M-Bb-ComponentModel-Attributes-PriorityAttribute-op_GreaterThanOrEqual-Bb-ComponentModel-Attributes-PriorityAttribute,Bb-ComponentModel-Attributes-PriorityAttribute- 'Bb.ComponentModel.Attributes.PriorityAttribute.op_GreaterThanOrEqual(Bb.ComponentModel.Attributes.PriorityAttribute,Bb.ComponentModel.Attributes.PriorityAttribute)')
  - [op_Inequality(left,right)](#M-Bb-ComponentModel-Attributes-PriorityAttribute-op_Inequality-Bb-ComponentModel-Attributes-PriorityAttribute,Bb-ComponentModel-Attributes-PriorityAttribute- 'Bb.ComponentModel.Attributes.PriorityAttribute.op_Inequality(Bb.ComponentModel.Attributes.PriorityAttribute,Bb.ComponentModel.Attributes.PriorityAttribute)')
  - [op_LessThan(left,right)](#M-Bb-ComponentModel-Attributes-PriorityAttribute-op_LessThan-Bb-ComponentModel-Attributes-PriorityAttribute,Bb-ComponentModel-Attributes-PriorityAttribute- 'Bb.ComponentModel.Attributes.PriorityAttribute.op_LessThan(Bb.ComponentModel.Attributes.PriorityAttribute,Bb.ComponentModel.Attributes.PriorityAttribute)')
  - [op_LessThanOrEqual(left,right)](#M-Bb-ComponentModel-Attributes-PriorityAttribute-op_LessThanOrEqual-Bb-ComponentModel-Attributes-PriorityAttribute,Bb-ComponentModel-Attributes-PriorityAttribute- 'Bb.ComponentModel.Attributes.PriorityAttribute.op_LessThanOrEqual(Bb.ComponentModel.Attributes.PriorityAttribute,Bb.ComponentModel.Attributes.PriorityAttribute)')
- [PriorityHelper](#T-Bb-ComponentModel-PriorityHelper 'Bb.ComponentModel.PriorityHelper')
  - [OrderByPriority(types)](#M-Bb-ComponentModel-PriorityHelper-OrderByPriority-System-Collections-Generic-IEnumerable{System-Type}- 'Bb.ComponentModel.PriorityHelper.OrderByPriority(System.Collections.Generic.IEnumerable{System.Type})')
- [ProviderListBase\`1](#T-Bb-ComponentModel-Attributes-ProviderListBase`1 'Bb.ComponentModel.Attributes.ProviderListBase`1')
  - [Instance](#P-Bb-ComponentModel-Attributes-ProviderListBase`1-Instance 'Bb.ComponentModel.Attributes.ProviderListBase`1.Instance')
  - [Property](#P-Bb-ComponentModel-Attributes-ProviderListBase`1-Property 'Bb.ComponentModel.Attributes.ProviderListBase`1.Property')
  - [Bb#ComponentModel#DataAnnotations#IListProvider#GetItems()](#M-Bb-ComponentModel-Attributes-ProviderListBase`1-Bb#ComponentModel#DataAnnotations#IListProvider#GetItems 'Bb.ComponentModel.Attributes.ProviderListBase`1.Bb#ComponentModel#DataAnnotations#IListProvider#GetItems')
  - [Bb#ComponentModel#DataAnnotations#IListProvider#GetOriginalValue(item)](#M-Bb-ComponentModel-Attributes-ProviderListBase`1-Bb#ComponentModel#DataAnnotations#IListProvider#GetOriginalValue-Bb-ComponentModel-DataAnnotations-ListItem- 'Bb.ComponentModel.Attributes.ProviderListBase`1.Bb#ComponentModel#DataAnnotations#IListProvider#GetOriginalValue(Bb.ComponentModel.DataAnnotations.ListItem)')
  - [Compare(left,right)](#M-Bb-ComponentModel-Attributes-ProviderListBase`1-Compare-Bb-ComponentModel-DataAnnotations-ListItem,System-Object- 'Bb.ComponentModel.Attributes.ProviderListBase`1.Compare(Bb.ComponentModel.DataAnnotations.ListItem,System.Object)')
  - [CreateItem(instance,display,value,initializer)](#M-Bb-ComponentModel-Attributes-ProviderListBase`1-CreateItem-`0,System-String,System-Object,System-Action{Bb-ComponentModel-DataAnnotations-ListItem{`0}}- 'Bb.ComponentModel.Attributes.ProviderListBase`1.CreateItem(`0,System.String,System.Object,System.Action{Bb.ComponentModel.DataAnnotations.ListItem{`0}})')
  - [GetItems()](#M-Bb-ComponentModel-Attributes-ProviderListBase`1-GetItems 'Bb.ComponentModel.Attributes.ProviderListBase`1.GetItems')
  - [GetValue()](#M-Bb-ComponentModel-Attributes-ProviderListBase`1-GetValue 'Bb.ComponentModel.Attributes.ProviderListBase`1.GetValue')
  - [ResolveOriginalValue(item)](#M-Bb-ComponentModel-Attributes-ProviderListBase`1-ResolveOriginalValue-Bb-ComponentModel-DataAnnotations-ListItem{`0}- 'Bb.ComponentModel.Attributes.ProviderListBase`1.ResolveOriginalValue(Bb.ComponentModel.DataAnnotations.ListItem{`0})')
- [RefreshEventArgs](#T-Bb-ComponentModel-RefreshEventArgs 'Bb.ComponentModel.RefreshEventArgs')
  - [#ctor(toRefresh)](#M-Bb-ComponentModel-RefreshEventArgs-#ctor-System-Object[]- 'Bb.ComponentModel.RefreshEventArgs.#ctor(System.Object[])')
  - [MustRefresh(o)](#M-Bb-ComponentModel-RefreshEventArgs-MustRefresh-System-Object- 'Bb.ComponentModel.RefreshEventArgs.MustRefresh(System.Object)')
- [StepNumericAttribute](#T-Bb-ComponentModel-Attributes-StepNumericAttribute 'Bb.ComponentModel.Attributes.StepNumericAttribute')
  - [#ctor(step)](#M-Bb-ComponentModel-Attributes-StepNumericAttribute-#ctor-System-Single- 'Bb.ComponentModel.Attributes.StepNumericAttribute.#ctor(System.Single)')
  - [Step](#P-Bb-ComponentModel-Attributes-StepNumericAttribute-Step 'Bb.ComponentModel.Attributes.StepNumericAttribute.Step')
- [TypeDescriptorExtension](#T-Bb-ComponentModel-TypeDescriptorExtension 'Bb.ComponentModel.TypeDescriptorExtension')
  - [GetAttributes\`\`1(self)](#M-Bb-ComponentModel-TypeDescriptorExtension-GetAttributes``1-System-Type- 'Bb.ComponentModel.TypeDescriptorExtension.GetAttributes``1(System.Type)')
  - [GetAttributes\`\`1(self,filterFunction)](#M-Bb-ComponentModel-TypeDescriptorExtension-GetAttributes``1-System-Type,System-Func{``0,System-Boolean}- 'Bb.ComponentModel.TypeDescriptorExtension.GetAttributes``1(System.Type,System.Func{``0,System.Boolean})')
  - [GetAttributes\`\`1(self)](#M-Bb-ComponentModel-TypeDescriptorExtension-GetAttributes``1-System-Reflection-PropertyInfo- 'Bb.ComponentModel.TypeDescriptorExtension.GetAttributes``1(System.Reflection.PropertyInfo)')
  - [GetAttributes\`\`1(self,filterFunction)](#M-Bb-ComponentModel-TypeDescriptorExtension-GetAttributes``1-System-Reflection-PropertyInfo,System-Func{``0,System-Boolean}- 'Bb.ComponentModel.TypeDescriptorExtension.GetAttributes``1(System.Reflection.PropertyInfo,System.Func{``0,System.Boolean})')
  - [GetProperties(self)](#M-Bb-ComponentModel-TypeDescriptorExtension-GetProperties-System-Type- 'Bb.ComponentModel.TypeDescriptorExtension.GetProperties(System.Type)')
  - [GetProperties(self,funcFilter)](#M-Bb-ComponentModel-TypeDescriptorExtension-GetProperties-System-Type,System-Func{System-ComponentModel-PropertyDescriptor,System-Boolean}- 'Bb.ComponentModel.TypeDescriptorExtension.GetProperties(System.Type,System.Func{System.ComponentModel.PropertyDescriptor,System.Boolean})')
- [UndefinedException](#T-Bb-ComponentModel-Exceptions-UndefinedException 'Bb.ComponentModel.Exceptions.UndefinedException')
  - [#ctor()](#M-Bb-ComponentModel-Exceptions-UndefinedException-#ctor 'Bb.ComponentModel.Exceptions.UndefinedException.#ctor')
  - [#ctor(variableName)](#M-Bb-ComponentModel-Exceptions-UndefinedException-#ctor-System-String- 'Bb.ComponentModel.Exceptions.UndefinedException.#ctor(System.String)')
  - [#ctor(message,inner)](#M-Bb-ComponentModel-Exceptions-UndefinedException-#ctor-System-String,System-Exception- 'Bb.ComponentModel.Exceptions.UndefinedException.#ctor(System.String,System.Exception)')
  - [#ctor(info,context)](#M-Bb-ComponentModel-Exceptions-UndefinedException-#ctor-System-Runtime-Serialization-SerializationInfo,System-Runtime-Serialization-StreamingContext- 'Bb.ComponentModel.Exceptions.UndefinedException.#ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)')

<a name='T-Bb-ComponentModel-Busy'></a>
## Busy `type`

##### Namespace

Bb.ComponentModel

##### Summary

Represents the status of a busy session.

<a name='F-Bb-ComponentModel-Busy-Completed'></a>
### Completed `constants`

##### Summary

The session has completed.

<a name='F-Bb-ComponentModel-Busy-New'></a>
### New `constants`

##### Summary

The session is newly created and has not started yet.

<a name='F-Bb-ComponentModel-Busy-Running'></a>
### Running `constants`

##### Summary

The session is currently running.

<a name='F-Bb-ComponentModel-Busy-Started'></a>
### Started `constants`

##### Summary

The session has started but is not yet running.

<a name='T-Bb-ComponentModel-BusyEventArgs'></a>
## BusyEventArgs `type`

##### Namespace

Bb.ComponentModel

##### Summary

Provides data for busy state events.

##### Remarks

This class is used to indicate the source of a busy state during a busy event.

<a name='M-Bb-ComponentModel-BusyEventArgs-#ctor-Bb-ComponentModel-BusySession-'></a>
### #ctor(source) `constructor`

##### Summary

Initializes a new instance of the [BusyEventArgs](#T-Bb-ComponentModel-BusyEventArgs 'Bb.ComponentModel.BusyEventArgs') class with the specified busy session.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [Bb.ComponentModel.BusySession](#T-Bb-ComponentModel-BusySession 'Bb.ComponentModel.BusySession') | The source of the busy session. |

##### Example

```C#
var busyArgs = new BusyEventArgs(session);
Console.WriteLine(busyArgs.Source);
```

<a name='P-Bb-ComponentModel-BusyEventArgs-Source'></a>
### Source `property`

##### Summary

Gets the source of the busy session.

##### Returns

The [BusySession](#T-Bb-ComponentModel-BusySession 'Bb.ComponentModel.BusySession') that represents the source of the busy state.

<a name='T-Bb-ComponentModel-BusySession'></a>
## BusySession `type`

##### Namespace

Bb.ComponentModel

##### Summary

Represents a session that tracks and manages a busy state.

##### Remarks

This class is used to manage actions that are executed in a busy state, providing progress updates and status tracking.

<a name='M-Bb-ComponentModel-BusySession-#ctor-Bb-ComponentModel-IBusyService,System-String,System-Object,System-Action{Bb-ComponentModel-BusySession}-'></a>
### #ctor(parent,title,parentInstance,action) `constructor`

##### Summary

Initializes a new instance of the [BusySession](#T-Bb-ComponentModel-BusySession 'Bb.ComponentModel.BusySession') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| parent | [Bb.ComponentModel.IBusyService](#T-Bb-ComponentModel-IBusyService 'Bb.ComponentModel.IBusyService') | The parent service managing the busy session. |
| title | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The title of the busy session. |
| parentInstance | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The instance being processed in the session. |
| action | [System.Action{Bb.ComponentModel.BusySession}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{Bb.ComponentModel.BusySession}') | The initial action to execute in the session. |

##### Remarks

This constructor sets up the busy session with an optional initial action.

<a name='P-Bb-ComponentModel-BusySession-BusyStatus'></a>
### BusyStatus `property`

##### Summary

Gets the current status of the busy session.

##### Returns

The current [Busy](#T-Bb-ComponentModel-Busy 'Bb.ComponentModel.Busy') status.

<a name='P-Bb-ComponentModel-BusySession-Instance'></a>
### Instance `property`

##### Summary

Gets the instance being processed in the busy session.

##### Returns

The instance being processed.

<a name='P-Bb-ComponentModel-BusySession-Message'></a>
### Message `property`

##### Summary

Gets the current message of the busy session.

##### Returns

The current message.

<a name='P-Bb-ComponentModel-BusySession-ProgressPercent'></a>
### ProgressPercent `property`

##### Summary

Gets the progress percentage of the busy session.

##### Returns

The progress percentage.

<a name='P-Bb-ComponentModel-BusySession-Title'></a>
### Title `property`

##### Summary

Gets or sets the title of the busy session.

##### Returns

The title of the session.

<a name='M-Bb-ComponentModel-BusySession-Add-System-Action{Bb-ComponentModel-BusySession}-'></a>
### Add(action) `method`

##### Summary

Appends a new action to execute in the busy session.

##### Returns

The current [BusySession](#T-Bb-ComponentModel-BusySession 'Bb.ComponentModel.BusySession') instance.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| action | [System.Action{Bb.ComponentModel.BusySession}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{Bb.ComponentModel.BusySession}') | The action to add to the session. |

##### Example

```C#
session.Add(s =&gt; Console.WriteLine("Action 1"))
       .Add(s =&gt; Console.WriteLine("Action 2"));
```

##### Remarks

This method allows chaining multiple actions to be executed during the session.

<a name='M-Bb-ComponentModel-BusySession-Close'></a>
### Close() `method`

##### Summary

Closes the busy session and marks it as completed.

##### Returns

A [Task](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.Tasks.Task 'System.Threading.Tasks.Task') representing the asynchronous operation.

##### Parameters

This method has no parameters.

##### Example

```C#
await session.Close();
```

##### Remarks

This method sets the session status to completed, clears the message, and sets the progress to 100%.

<a name='M-Bb-ComponentModel-BusySession-Dispose-System-Boolean-'></a>
### Dispose(disposing) `method`

##### Summary

Disposes the busy session and marks it as completed.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| disposing | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Indicates whether the method is called from Dispose or the finalizer. |

##### Remarks

This method ensures that the session is properly closed and resources are released.

<a name='M-Bb-ComponentModel-BusySession-Dispose'></a>
### Dispose() `method`

##### Summary

Disposes the busy session and marks it as completed.

##### Parameters

This method has no parameters.

##### Remarks

This method ensures that the session is properly closed and resources are released.

<a name='M-Bb-ComponentModel-BusySession-Run'></a>
### Run() `method`

##### Summary

Runs the busy session and executes all added actions.

##### Returns

A [Task](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.Tasks.Task 'System.Threading.Tasks.Task') representing the asynchronous operation.

##### Parameters

This method has no parameters.

##### Example

```C#
await session.Run();
```

##### Remarks

This method sets the session status to running, executes all actions, and then marks the session as completed.

<a name='M-Bb-ComponentModel-BusySession-Update-System-String,System-Int32-'></a>
### Update(message,percent) `method`

##### Summary

Updates the message and progress of the busy session.

##### Returns

A [Task](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.Tasks.Task 'System.Threading.Tasks.Task') representing the asynchronous operation.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| message | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The new message to display (optional). |
| percent | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The progress percentage (optional, default is -1). |

##### Example

```C#
await session.Update("Processing...", 50);
```

##### Remarks

This method updates the session's message and progress percentage and notifies subscribers of the changes.

<a name='T-Bb-ComponentModel-Attributes-ConfigurationAttribute'></a>
## ConfigurationAttribute `type`

##### Namespace

Bb.ComponentModel.Attributes

##### Summary

Specifies configuration metadata for a class.

##### Remarks

This attribute is used to define configuration-related properties for a class, such as the configuration key and serialization type.

<a name='M-Bb-ComponentModel-Attributes-ConfigurationAttribute-#ctor'></a>
### #ctor() `constructor`

##### Summary

Initializes a new instance of the [ConfigurationAttribute](#T-Bb-ComponentModel-Attributes-ConfigurationAttribute 'Bb.ComponentModel.Attributes.ConfigurationAttribute') class.

##### Parameters

This constructor has no parameters.

<a name='F-Bb-ComponentModel-Attributes-ConfigurationAttribute-TypeSerializationToJson'></a>
### TypeSerializationToJson `constants`

##### Summary

Represents the JSON serialization type.

<a name='F-Bb-ComponentModel-Attributes-ConfigurationAttribute-TypeSerializationToXml'></a>
### TypeSerializationToXml `constants`

##### Summary

Represents the XML serialization type.

<a name='F-Bb-ComponentModel-Attributes-ConfigurationAttribute-TypeSerializationToYml'></a>
### TypeSerializationToYml `constants`

##### Summary

Represents the YAML serialization type.

<a name='P-Bb-ComponentModel-Attributes-ConfigurationAttribute-ConfigurationKey'></a>
### ConfigurationKey `property`

##### Summary

Gets or sets the configuration key associated with the class.

##### Remarks

The configuration key is used to identify the configuration section or entry for the class.

<a name='P-Bb-ComponentModel-Attributes-ConfigurationAttribute-TypeSerialization'></a>
### TypeSerialization `property`

##### Summary

Gets or sets the serialization type for the configuration.

##### Remarks

Supported serialization types include JSON, XML, and YAML.

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

##### Summary

Provides a list of cultures to use in a list selector

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

##### Summary

Indicates that a class depends on another class.

<a name='M-Bb-ComponentModel-Attributes-DependOfAttribute-#ctor-System-Type-'></a>
### #ctor(type) `constructor`

##### Summary

Ctor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') |  |

<a name='P-Bb-ComponentModel-Attributes-DependOfAttribute-Type'></a>
### Type `property`

##### Summary

Gets the type that this class depends on.

<a name='T-Bb-ComponentModel-Attributes-DisplayOnUITextAreaAttribute'></a>
## DisplayOnUITextAreaAttribute `type`

##### Namespace

Bb.ComponentModel.Attributes

##### Summary

Attribute to indicate that a property should be displayed as a text area in the UI.

<a name='M-Bb-ComponentModel-Attributes-DisplayOnUITextAreaAttribute-#ctor-System-Int32-'></a>
### #ctor(lines) `constructor`

##### Summary

Initializes a new instance of the [DisplayOnUITextAreaAttribute](#T-Bb-ComponentModel-Attributes-DisplayOnUITextAreaAttribute 'Bb.ComponentModel.Attributes.DisplayOnUITextAreaAttribute') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| lines | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') |  |

<a name='P-Bb-ComponentModel-Attributes-DisplayOnUITextAreaAttribute-Lines'></a>
### Lines `property`

##### Summary

Gets the number of lines to display in the text area.

<a name='T-Bb-ComponentModel-Attributes-EnumerationProviderAttribute'></a>
## EnumerationProviderAttribute `type`

##### Namespace

Bb.ComponentModel.Attributes

##### Summary

Enumeration provider attribute

<a name='M-Bb-ComponentModel-Attributes-EnumerationProviderAttribute-#ctor-System-Type-'></a>
### #ctor(typeProvider) `constructor`

##### Summary

Initializes a new instance of the [EnumerationProviderAttribute](#T-Bb-ComponentModel-Attributes-EnumerationProviderAttribute 'Bb.ComponentModel.Attributes.EnumerationProviderAttribute') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| typeProvider | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') |  |

<a name='P-Bb-ComponentModel-Attributes-EnumerationProviderAttribute-Provider'></a>
### Provider `property`

##### Summary

Gets the type to use like provider.

<a name='T-Bb-ComponentModel-Attributes-EvaluateValidationAttribute'></a>
## EvaluateValidationAttribute `type`

##### Namespace

Bb.ComponentModel.Attributes

##### Summary

Attribute to indicate that a property should be evaluated for validation.

<a name='M-Bb-ComponentModel-Attributes-EvaluateValidationAttribute-#ctor-System-Boolean-'></a>
### #ctor(toEvaluate) `constructor`

##### Summary

Initializes a new instance of the [EvaluateValidationAttribute](#T-Bb-ComponentModel-Attributes-EvaluateValidationAttribute 'Bb.ComponentModel.Attributes.EvaluateValidationAttribute') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| toEvaluate | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') |  |

<a name='P-Bb-ComponentModel-Attributes-EvaluateValidationAttribute-ToEvaluate'></a>
### ToEvaluate `property`

##### Summary

Gets a value indicating whether the property should be evaluated for validation.

<a name='T-Bb-ComponentModel-EvaluatorEventArgs`1'></a>
## EvaluatorEventArgs\`1 `type`

##### Namespace

Bb.ComponentModel

##### Summary

Event arguments for an evaluator that evaluates and executes actions on a target object.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The type of the target object to evaluate. |

<a name='M-Bb-ComponentModel-EvaluatorEventArgs`1-#ctor-System-Func{`0,System-Object,System-Boolean},System-Action{`0,System-Object}-'></a>
### #ctor(evaluator,action) `constructor`

##### Summary

Initializes a new instance of the [EvaluatorEventArgs\`1](#T-Bb-ComponentModel-EvaluatorEventArgs`1 'Bb.ComponentModel.EvaluatorEventArgs`1') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| evaluator | [System.Func{\`0,System.Object,System.Boolean}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{`0,System.Object,System.Boolean}') | The function used to evaluate the target object with a value. Can be `null`. |
| action | [System.Action{\`0,System.Object}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{`0,System.Object}') | The action to execute if the evaluation passes. Can be `null`. |

##### Example

```C#
var args = new EvaluatorEventArgs&lt;string&gt;(
    (target, value) =&gt; target.Length &gt; 5,
    (target, value) =&gt; Console.WriteLine($"Target: {target}, Value: {value}")
);
args.Evaluate("Example", 42);
```

##### Remarks

The evaluator function determines whether the action should be executed. If the evaluator is `null`, the action will always be executed.

<a name='M-Bb-ComponentModel-EvaluatorEventArgs`1-Evaluate-`0,System-Object-'></a>
### Evaluate(target,value) `method`

##### Summary

Evaluates the target object with the specified value.

##### Returns

`true` if the evaluation passes or if the evaluator function is `null`; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| target | [\`0](#T-`0 '`0') | The target object to evaluate. |
| value | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The value to evaluate the target object with. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown when the `target` object is `null`. |

##### Example

```C#
var args = new EvaluatorEventArgs&lt;string&gt;(
    (target, value) =&gt; target.Length &gt; 5,
    (target, value) =&gt; Console.WriteLine($"Target: {target}, Value: {value}")
);
bool result = args.Evaluate("Example", 42);
```

##### Remarks

This method evaluates the target object with the specified value using the provided evaluator function.
If the evaluator function is `null` or returns `true`, the action function will be invoked with the target object and the value.

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

<a name='P-Bb-ComponentModel-Attributes-ExposeClassAttribute-TypeId'></a>
### TypeId `property`

##### Summary

Gets the type identifier for this instance.

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

##### Summary

Specifies that a method should be exposed with additional metadata.

##### Remarks

This attribute is used to mark methods for exposure with optional context, type, and display name metadata.

<a name='M-Bb-ComponentModel-Attributes-ExposeMethodAttribute-#ctor'></a>
### #ctor() `constructor`

##### Summary

Initializes a new instance of the [ExposeMethodAttribute](#T-Bb-ComponentModel-Attributes-ExposeMethodAttribute 'Bb.ComponentModel.Attributes.ExposeMethodAttribute') class.

##### Parameters

This constructor has no parameters.

##### Example

```C#
[ExposeMethod]
public void MyMethod() { }
```

##### Remarks

This constructor is used when no additional metadata is required.

<a name='M-Bb-ComponentModel-Attributes-ExposeMethodAttribute-#ctor-System-String-'></a>
### #ctor(displayName) `constructor`

##### Summary

Initializes a new instance of the [ExposeMethodAttribute](#T-Bb-ComponentModel-Attributes-ExposeMethodAttribute 'Bb.ComponentModel.Attributes.ExposeMethodAttribute') class with a display name.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| displayName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The display name for the method, used as a key for matching rules. |

##### Example

```C#
[ExposeMethod("MyMethod")]
public void MyMethod() { }
```

<a name='M-Bb-ComponentModel-Attributes-ExposeMethodAttribute-#ctor-System-String,System-String-'></a>
### #ctor(context,displayName) `constructor`

##### Summary

Initializes a new instance of the [ExposeMethodAttribute](#T-Bb-ComponentModel-Attributes-ExposeMethodAttribute 'Bb.ComponentModel.Attributes.ExposeMethodAttribute') class with a context and display name.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| context | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The context in which the method is exposed. |
| displayName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The display name for the method, used as a key for matching rules. |

##### Example

```C#
[ExposeMethod("Admin", "MyMethod")]
public void MyMethod() { }
```

<a name='M-Bb-ComponentModel-Attributes-ExposeMethodAttribute-#ctor-System-String,Bb-ComponentModel-Attributes-MethodType,System-String-'></a>
### #ctor(context,kind,displayName) `constructor`

##### Summary

Initializes a new instance of the [ExposeMethodAttribute](#T-Bb-ComponentModel-Attributes-ExposeMethodAttribute 'Bb.ComponentModel.Attributes.ExposeMethodAttribute') class with a context, method type, and display name.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| context | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The context in which the method is exposed. |
| kind | [Bb.ComponentModel.Attributes.MethodType](#T-Bb-ComponentModel-Attributes-MethodType 'Bb.ComponentModel.Attributes.MethodType') | The type of the method, indicating its purpose. |
| displayName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The display name for the method, used as a key for matching rules. |

##### Example

```C#
[ExposeMethod("Admin", MethodType.Add, "AddUser")]
public void AddUser() { }
```

<a name='P-Bb-ComponentModel-Attributes-ExposeMethodAttribute-Context'></a>
### Context `property`

##### Summary

Gets the context in which the method is exposed.

##### Remarks

The context can be used to group or categorize exposed methods.

<a name='P-Bb-ComponentModel-Attributes-ExposeMethodAttribute-DisplayName'></a>
### DisplayName `property`

##### Summary

Gets the display name for the method.

##### Remarks

The display name is used as a key for matching rules.

<a name='P-Bb-ComponentModel-Attributes-ExposeMethodAttribute-Kind'></a>
### Kind `property`

##### Summary

Gets the type of the method, indicating its purpose.

##### Remarks

The method type can be used to specify the role of the method, such as adding, deleting, or creating new items.

<a name='T-Bb-ComponentModel-Attributes-ExposedAttributeTypeConfiguration'></a>
## ExposedAttributeTypeConfiguration `type`

##### Namespace

Bb.ComponentModel.Attributes

##### Summary

ExposedAttributeTypeConfiguration

<a name='M-Bb-ComponentModel-Attributes-ExposedAttributeTypeConfiguration-#ctor'></a>
### #ctor() `constructor`

##### Summary

Initializes a new instance of the [ExposedAttributeTypeConfiguration](#T-Bb-ComponentModel-Attributes-ExposedAttributeTypeConfiguration 'Bb.ComponentModel.Attributes.ExposedAttributeTypeConfiguration') class.

##### Parameters

This constructor has no parameters.

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

<a name='T-Bb-ComponentModel-IApplicationBuilderInitializer'></a>
## IApplicationBuilderInitializer `type`

##### Namespace

Bb.ComponentModel

##### Summary



<a name='P-Bb-ComponentModel-IApplicationBuilderInitializer-Executed'></a>
### Executed `property`

##### Summary

return true if the builder has been Initialized

##### Remarks

This method returns a boolean value indicating whether the builder has been initialized.

<a name='P-Bb-ComponentModel-IApplicationBuilderInitializer-FriendlyName'></a>
### FriendlyName `property`

##### Summary

Friendly name of the builder

##### Remarks

This method returns the friendly name of the builder.

<a name='P-Bb-ComponentModel-IApplicationBuilderInitializer-OrderPriority'></a>
### OrderPriority `property`

##### Summary

Order of initialization

##### Remarks

This method returns the order to execute in the list of initialization.

<a name='P-Bb-ComponentModel-IApplicationBuilderInitializer-Type'></a>
### Type `property`

##### Summary

Return the type of service that should be passed by argument

##### Remarks

This method returns the type of service that should be passed as an argument.

<a name='T-Bb-ComponentModel-IBusyService'></a>
## IBusyService `type`

##### Namespace

Bb.ComponentModel

##### Summary

Busy service

##### Remarks

This service provides functionality for managing busy sessions.
A busy session represents a period of time during which a specific instance is busy performing an action.
The service allows subscribing to the BusyChanged event to be notified when the busy state changes.

<a name='M-Bb-ComponentModel-IBusyService-IsBusyFor-System-Object,System-String,System-Action{Bb-ComponentModel-BusySession}-'></a>
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
| action | [System.Action{Bb.ComponentModel.BusySession}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{Bb.ComponentModel.BusySession}') | The action to execute if the instance is not busy. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if the instance parameter is null. |

<a name='M-Bb-ComponentModel-IBusyService-Update-Bb-ComponentModel-BusySession-'></a>
### Update(session) `method`

##### Summary

Updates the specified busy session.

##### Returns

A task representing the asynchronous operation.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| session | [Bb.ComponentModel.BusySession](#T-Bb-ComponentModel-BusySession 'Bb.ComponentModel.BusySession') | The busy session to update. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if the session parameter is null. |

<a name='T-Bb-ComponentModel-IFocusedService`1'></a>
## IFocusedService\`1 `type`

##### Namespace

Bb.ComponentModel

##### Summary

Project the focused object on target object

<a name='M-Bb-ComponentModel-IFocusedService`1-FocusChange-System-Object,System-Func{`0,System-Object,System-Boolean}-'></a>
### FocusChange(sender,test) `method`

##### Summary

Project the object on focus

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | object source |
| test | [System.Func{\`0,System.Object,System.Boolean}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{`0,System.Object,System.Boolean}') | Test to evaluate before change the focus |

<a name='M-Bb-ComponentModel-IFocusedService`1-FocusChange-System-Object,System-Func{`0,System-Object,System-Boolean},System-Action{`0,System-Object}-'></a>
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
| context | [\`0](#T-`0 '`0') | specified context |

<a name='M-Bb-ComponentModel-IInjectBuilder`1-Execute-`0-'></a>
### Execute(context) `method`

##### Summary

Execute the initializing process with

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| context | [\`0](#T-`0 '`0') | specified context |

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

<a name='M-Bb-ComponentModel-DataAnnotations-IListProvider-Compare-Bb-ComponentModel-DataAnnotations-ListItem,System-Object-'></a>
### Compare(left,right) `method`

##### Summary

Compare the value of the list item with the value

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| left | [Bb.ComponentModel.DataAnnotations.ListItem](#T-Bb-ComponentModel-DataAnnotations-ListItem 'Bb.ComponentModel.DataAnnotations.ListItem') |  |
| right | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') |  |

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

<a name='T-Bb-ComponentModel-DataAnnotations-ILogin'></a>
## ILogin `type`

##### Namespace

Bb.ComponentModel.DataAnnotations

##### Summary

Represents a login model.

<a name='P-Bb-ComponentModel-DataAnnotations-ILogin-Login'></a>
### Login `property`

##### Summary

Gets or sets the login name.

<a name='P-Bb-ComponentModel-DataAnnotations-ILogin-Password'></a>
### Password `property`

##### Summary

Gets or sets the password.

<a name='T-Bb-ComponentModel-IProjectedService`1'></a>
## IProjectedService\`1 `type`

##### Namespace

Bb.ComponentModel

##### Summary

Project the focused object on target object

<a name='M-Bb-ComponentModel-IProjectedService`1-Execute-System-Action{`0,System-Object}-'></a>
### Execute(action) `method`

##### Summary

Listen the focus change

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| action | [System.Action{\`0,System.Object}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{`0,System.Object}') | action to execute |

<a name='M-Bb-ComponentModel-IProjectedService`1-FocusChange-System-Object,System-Func{`0,System-Object,System-Boolean}-'></a>
### FocusChange(sender,test) `method`

##### Summary

Project the object on focus

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | object source |
| test | [System.Func{\`0,System.Object,System.Boolean}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{`0,System.Object,System.Boolean}') | Test to evaluate before change the focus |

<a name='M-Bb-ComponentModel-IProjectedService`1-Register-`0-'></a>
### Register(service) `method`

##### Summary

Register the service

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| service | [\`0](#T-`0 '`0') |  |

<a name='T-Bb-ComponentModel-IRefreshService'></a>
## IRefreshService `type`

##### Namespace

Bb.ComponentModel

##### Summary

Defines a service for handling refresh requests.

##### Remarks

This interface provides an event and a method to request refresh operations for specific objects.

<a name='M-Bb-ComponentModel-IRefreshService-CallRequestRefresh-System-Object,System-Object[]-'></a>
### CallRequestRefresh(sender,toRefresh) `method`

##### Summary

Requests a refresh for the specified objects.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The source of the refresh request. |
| toRefresh | [System.Object[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object[] 'System.Object[]') | The objects that need to be refreshed. |

##### Example

```C#
IRefreshService refreshService = ...;
refreshService.CallRequestRefresh(this, obj1, obj2);
```

##### Remarks

This method raises the [](#E-Bb-ComponentModel-IRefreshService-RefreshRequested 'Bb.ComponentModel.IRefreshService.RefreshRequested') event to notify subscribers about the refresh request.

<a name='T-Bb-ComponentModel-InjectBuilder'></a>
## InjectBuilder `type`

##### Namespace

Bb.ComponentModel

##### Summary

Class base that implement default behavior for [IInjectBuilder](#T-Bb-ComponentModel-IInjectBuilder 'Bb.ComponentModel.IInjectBuilder')

<a name='P-Bb-ComponentModel-InjectBuilder-FilterToLaunch'></a>
### FilterToLaunch `property`

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
| context | [\`0](#T-`0 '`0') | specified context |

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

Execute the initializing process

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| context | [\`0](#T-`0 '`0') | specified context |

<a name='T-Bb-ComponentModel-Attributes-InjectByIocAttribute'></a>
## InjectByIocAttribute `type`

##### Namespace

Bb.ComponentModel.Attributes

##### Summary

Specifies that a property should be injected by an IoC (Inversion of Control) container.

##### Remarks

This attribute is used to mark properties for dependency injection using an IoC container.

<a name='M-Bb-ComponentModel-Attributes-InjectByIocAttribute-#ctor'></a>
### #ctor() `constructor`

##### Summary

Initializes a new instance of the [InjectByIocAttribute](#T-Bb-ComponentModel-Attributes-InjectByIocAttribute 'Bb.ComponentModel.Attributes.InjectByIocAttribute') class.

##### Parameters

This constructor has no parameters.

##### Example

```C#
[InjectByIoc]
public IService MyService { get; set; }
```

##### Remarks

This constructor is used when no specific type is specified for injection.

<a name='M-Bb-ComponentModel-Attributes-InjectByIocAttribute-#ctor-System-Type-'></a>
### #ctor(type) `constructor`

##### Summary

Initializes a new instance of the [InjectByIocAttribute](#T-Bb-ComponentModel-Attributes-InjectByIocAttribute 'Bb.ComponentModel.Attributes.InjectByIocAttribute') class with the specified type.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | The type to inject into the property. |

##### Example

```C#
[InjectByIoc(typeof(MyService))]
public IService MyService { get; set; }
```

##### Remarks

This constructor is used when a specific type is required for injection.

<a name='P-Bb-ComponentModel-Attributes-InjectByIocAttribute-TypeToInject'></a>
### TypeToInject `property`

##### Summary

Gets the type to inject into the property.

##### Returns

The type specified for injection, or `null` if no type was specified.

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

<a name='M-Bb-ComponentModel-Attributes-InjectorPolicyAttribute-#ctor-System-Type,Bb-ComponentModel-Attributes-IocScope-'></a>
### #ctor(type,lifeCycle) `constructor`

##### Summary

Ctor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') |  |
| lifeCycle | [Bb.ComponentModel.Attributes.IocScope](#T-Bb-ComponentModel-Attributes-IocScope 'Bb.ComponentModel.Attributes.IocScope') |  |

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

<a name='T-Bb-ComponentModel-Attributes-IocScope'></a>
## IocScope `type`

##### Namespace

Bb.ComponentModel.Attributes

##### Summary

Specifies the scope of an IoC (Inversion of Control) container registration.

##### Remarks

This enumeration is used to define the life cycle of a service in an IoC container.

<a name='F-Bb-ComponentModel-Attributes-IocScope-Scoped'></a>
### Scoped `constants`

##### Summary

Specifies that a new instance of the service will be created for each scope.

<a name='F-Bb-ComponentModel-Attributes-IocScope-Singleton'></a>
### Singleton `constants`

##### Summary

Specifies that a single instance of the service will be created and shared across all requests.

<a name='F-Bb-ComponentModel-Attributes-IocScope-Transiant'></a>
### Transiant `constants`

##### Summary

Specifies that a new instance of the service will be created each time it is requested.

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

<a name='P-Bb-ComponentModel-DataAnnotations-ListItem-Icon'></a>
### Icon `property`

##### Summary

Image or icon to display in the list item.

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

<a name='P-Bb-ComponentModel-DataAnnotations-ListItem-Tag'></a>
### Tag `property`

##### Summary

Gets or sets the tag.

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
### Equals(obj) `method`

##### Summary

return true if the value is equal to the value of the object

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| obj | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | object to evaluate |

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

##### Summary

Specifies a list provider for a property or field.

<a name='M-Bb-ComponentModel-Attributes-ListProviderAttribute-#ctor-System-Type-'></a>
### #ctor(typeListResolver) `constructor`

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

<a name='P-Bb-ComponentModel-Attributes-ListProviderAttribute-ProviderListType'></a>
### ProviderListType `property`

##### Summary

Gets the type of the list provider.

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

Represents metadata for a property.

##### Remarks

This attribute is used to define additional metadata for properties, fields, events, or parameters.

<a name='M-Bb-ComponentModel-Attributes-MetaPropertyAttribute-#ctor-System-String,System-String,System-Object-'></a>
### #ctor(context,name,value) `constructor`

##### Summary

Initializes a new instance of the [MetaPropertyAttribute](#T-Bb-ComponentModel-Attributes-MetaPropertyAttribute 'Bb.ComponentModel.Attributes.MetaPropertyAttribute') class with the specified context, name, and value.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| context | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The context in which the meta property is used. |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name of the meta property. |
| value | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The value of the meta property. |

##### Example

```C#
[MetaProperty("UI", "DisplayName", "My Property")]
public string MyProperty { get; set; }
```

<a name='P-Bb-ComponentModel-Attributes-MetaPropertyAttribute-Context'></a>
### Context `property`

##### Summary

Gets the context in which the meta property is used.

##### Returns

The context of the meta property.

<a name='P-Bb-ComponentModel-Attributes-MetaPropertyAttribute-Name'></a>
### Name `property`

##### Summary

Gets the name of the meta property.

##### Returns

The name of the meta property.

<a name='P-Bb-ComponentModel-Attributes-MetaPropertyAttribute-Type'></a>
### Type `property`

##### Summary

Gets or sets the type of the meta property.

##### Returns

The type of the meta property.

<a name='P-Bb-ComponentModel-Attributes-MetaPropertyAttribute-Value'></a>
### Value `property`

##### Summary

Gets the value of the meta property.

##### Returns

The value of the meta property.

<a name='T-Bb-ComponentModel-Attributes-MethodType'></a>
## MethodType `type`

##### Namespace

Bb.ComponentModel.Attributes

##### Summary

Specifies the type of a method, indicating its purpose.

<a name='F-Bb-ComponentModel-Attributes-MethodType-Add'></a>
### Add `constants`

##### Summary

Represents a method used for adding items.

<a name='F-Bb-ComponentModel-Attributes-MethodType-Del'></a>
### Del `constants`

##### Summary

Represents a method used for deleting items.

<a name='F-Bb-ComponentModel-Attributes-MethodType-New'></a>
### New `constants`

##### Summary

Represents a method used for creating new items.

<a name='F-Bb-ComponentModel-Attributes-MethodType-Other'></a>
### Other `constants`

##### Summary

Represents a method with an unspecified or other purpose.

<a name='T-Bb-ComponentModel-Attributes-OrderDisplayAttribute'></a>
## OrderDisplayAttribute `type`

##### Namespace

Bb.ComponentModel.Attributes

##### Summary

Specifies the display order of a property, field, event, or parameter.

##### Remarks

This attribute is used to define the position of an element in a display order, such as in a UI or serialization context.

<a name='M-Bb-ComponentModel-Attributes-OrderDisplayAttribute-#ctor-System-Int32-'></a>
### #ctor(position) `constructor`

##### Summary

Initializes a new instance of the [OrderDisplayAttribute](#T-Bb-ComponentModel-Attributes-OrderDisplayAttribute 'Bb.ComponentModel.Attributes.OrderDisplayAttribute') class with the specified position.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| position | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The position of the element in the display order. |

##### Example

```C#
[OrderDisplay(1)]
public string Name { get; set; }
```

<a name='P-Bb-ComponentModel-Attributes-OrderDisplayAttribute-Position'></a>
### Position `property`

##### Summary

Gets the position of the element in the display order.

##### Returns

The position value.

<a name='T-Bb-ComponentModel-Attributes-PriorityAttribute'></a>
## PriorityAttribute `type`

##### Namespace

Bb.ComponentModel.Attributes

##### Summary

Specifies the priority of a class.

##### Remarks

This attribute is used to assign a priority value to a class, which can be used for sorting or ordering purposes.

<a name='M-Bb-ComponentModel-Attributes-PriorityAttribute-#ctor-System-Int32-'></a>
### #ctor(priority) `constructor`

##### Summary

Initializes a new instance of the [PriorityAttribute](#T-Bb-ComponentModel-Attributes-PriorityAttribute 'Bb.ComponentModel.Attributes.PriorityAttribute') class with the specified priority.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| priority | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The priority value to assign to the class. |

##### Example

```C#
[Priority(1)]
public class MyClass { }
```

<a name='P-Bb-ComponentModel-Attributes-PriorityAttribute-Priority'></a>
### Priority `property`

##### Summary

Gets the priority value assigned to the class.

##### Returns

The priority value.

<a name='M-Bb-ComponentModel-Attributes-PriorityAttribute-CompareTo-Bb-ComponentModel-Attributes-PriorityAttribute-'></a>
### CompareTo(other) `method`

##### Summary

Compares the current [PriorityAttribute](#T-Bb-ComponentModel-Attributes-PriorityAttribute 'Bb.ComponentModel.Attributes.PriorityAttribute') with another [PriorityAttribute](#T-Bb-ComponentModel-Attributes-PriorityAttribute 'Bb.ComponentModel.Attributes.PriorityAttribute') to determine their relative order.

##### Returns

A value less than zero if this instance precedes `other` in the sort order;
zero if they are equal; or a value greater than zero if this instance follows `other`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| other | [Bb.ComponentModel.Attributes.PriorityAttribute](#T-Bb-ComponentModel-Attributes-PriorityAttribute 'Bb.ComponentModel.Attributes.PriorityAttribute') | The other [PriorityAttribute](#T-Bb-ComponentModel-Attributes-PriorityAttribute 'Bb.ComponentModel.Attributes.PriorityAttribute') to compare with. |

##### Remarks

If `other` is `null`, this instance is considered to have a higher priority.

<a name='M-Bb-ComponentModel-Attributes-PriorityAttribute-Equals-System-Object-'></a>
### Equals(obj) `method`

##### Summary

Determines whether the specified object is equal to the current [PriorityAttribute](#T-Bb-ComponentModel-Attributes-PriorityAttribute 'Bb.ComponentModel.Attributes.PriorityAttribute').

##### Returns

`true` if the specified object is equal to the current [PriorityAttribute](#T-Bb-ComponentModel-Attributes-PriorityAttribute 'Bb.ComponentModel.Attributes.PriorityAttribute'); otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| obj | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The object to compare with the current [PriorityAttribute](#T-Bb-ComponentModel-Attributes-PriorityAttribute 'Bb.ComponentModel.Attributes.PriorityAttribute'). |

<a name='M-Bb-ComponentModel-Attributes-PriorityAttribute-GetHashCode'></a>
### GetHashCode() `method`

##### Summary

Returns the hash code for the current [PriorityAttribute](#T-Bb-ComponentModel-Attributes-PriorityAttribute 'Bb.ComponentModel.Attributes.PriorityAttribute').

##### Returns

The hash code for the current [PriorityAttribute](#T-Bb-ComponentModel-Attributes-PriorityAttribute 'Bb.ComponentModel.Attributes.PriorityAttribute').

##### Parameters

This method has no parameters.

<a name='M-Bb-ComponentModel-Attributes-PriorityAttribute-ResolvePriority-System-Type-'></a>
### ResolvePriority(type) `method`

##### Summary

Resolves the priority value for a specified type.

##### Returns

The priority value of the type, or a default value of 10000 if no priority is specified.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | The type for which to resolve the priority. |

##### Example

```C#
int priority = PriorityAttribute.ResolvePriority(typeof(MyClass));
```

##### Remarks

This method retrieves the priority value from the [PriorityAttribute](#T-Bb-ComponentModel-Attributes-PriorityAttribute 'Bb.ComponentModel.Attributes.PriorityAttribute') applied to the specified type.

<a name='M-Bb-ComponentModel-Attributes-PriorityAttribute-op_Equality-Bb-ComponentModel-Attributes-PriorityAttribute,Bb-ComponentModel-Attributes-PriorityAttribute-'></a>
### op_Equality(left,right) `method`

##### Summary

Determines whether two [PriorityAttribute](#T-Bb-ComponentModel-Attributes-PriorityAttribute 'Bb.ComponentModel.Attributes.PriorityAttribute') instances are equal.

##### Returns

`true` if the priority values are equal; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| left | [Bb.ComponentModel.Attributes.PriorityAttribute](#T-Bb-ComponentModel-Attributes-PriorityAttribute 'Bb.ComponentModel.Attributes.PriorityAttribute') | The first [PriorityAttribute](#T-Bb-ComponentModel-Attributes-PriorityAttribute 'Bb.ComponentModel.Attributes.PriorityAttribute') to compare. |
| right | [Bb.ComponentModel.Attributes.PriorityAttribute](#T-Bb-ComponentModel-Attributes-PriorityAttribute 'Bb.ComponentModel.Attributes.PriorityAttribute') | The second [PriorityAttribute](#T-Bb-ComponentModel-Attributes-PriorityAttribute 'Bb.ComponentModel.Attributes.PriorityAttribute') to compare. |

<a name='M-Bb-ComponentModel-Attributes-PriorityAttribute-op_GreaterThan-Bb-ComponentModel-Attributes-PriorityAttribute,Bb-ComponentModel-Attributes-PriorityAttribute-'></a>
### op_GreaterThan(left,right) `method`

##### Summary

Determines whether the priority of one [PriorityAttribute](#T-Bb-ComponentModel-Attributes-PriorityAttribute 'Bb.ComponentModel.Attributes.PriorityAttribute') is greater than another.

##### Returns

`true` if the priority of `left` is greater than `right`; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| left | [Bb.ComponentModel.Attributes.PriorityAttribute](#T-Bb-ComponentModel-Attributes-PriorityAttribute 'Bb.ComponentModel.Attributes.PriorityAttribute') | The first [PriorityAttribute](#T-Bb-ComponentModel-Attributes-PriorityAttribute 'Bb.ComponentModel.Attributes.PriorityAttribute') to compare. |
| right | [Bb.ComponentModel.Attributes.PriorityAttribute](#T-Bb-ComponentModel-Attributes-PriorityAttribute 'Bb.ComponentModel.Attributes.PriorityAttribute') | The second [PriorityAttribute](#T-Bb-ComponentModel-Attributes-PriorityAttribute 'Bb.ComponentModel.Attributes.PriorityAttribute') to compare. |

<a name='M-Bb-ComponentModel-Attributes-PriorityAttribute-op_GreaterThanOrEqual-Bb-ComponentModel-Attributes-PriorityAttribute,Bb-ComponentModel-Attributes-PriorityAttribute-'></a>
### op_GreaterThanOrEqual(left,right) `method`

##### Summary

Determines whether the priority of one [PriorityAttribute](#T-Bb-ComponentModel-Attributes-PriorityAttribute 'Bb.ComponentModel.Attributes.PriorityAttribute') is greater than or equal to another.

##### Returns

`true` if the priority of `left` is greater than or equal to `right`; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| left | [Bb.ComponentModel.Attributes.PriorityAttribute](#T-Bb-ComponentModel-Attributes-PriorityAttribute 'Bb.ComponentModel.Attributes.PriorityAttribute') | The first [PriorityAttribute](#T-Bb-ComponentModel-Attributes-PriorityAttribute 'Bb.ComponentModel.Attributes.PriorityAttribute') to compare. |
| right | [Bb.ComponentModel.Attributes.PriorityAttribute](#T-Bb-ComponentModel-Attributes-PriorityAttribute 'Bb.ComponentModel.Attributes.PriorityAttribute') | The second [PriorityAttribute](#T-Bb-ComponentModel-Attributes-PriorityAttribute 'Bb.ComponentModel.Attributes.PriorityAttribute') to compare. |

<a name='M-Bb-ComponentModel-Attributes-PriorityAttribute-op_Inequality-Bb-ComponentModel-Attributes-PriorityAttribute,Bb-ComponentModel-Attributes-PriorityAttribute-'></a>
### op_Inequality(left,right) `method`

##### Summary

Determines whether two [PriorityAttribute](#T-Bb-ComponentModel-Attributes-PriorityAttribute 'Bb.ComponentModel.Attributes.PriorityAttribute') instances are not equal.

##### Returns

`true` if the priority values are not equal; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| left | [Bb.ComponentModel.Attributes.PriorityAttribute](#T-Bb-ComponentModel-Attributes-PriorityAttribute 'Bb.ComponentModel.Attributes.PriorityAttribute') | The first [PriorityAttribute](#T-Bb-ComponentModel-Attributes-PriorityAttribute 'Bb.ComponentModel.Attributes.PriorityAttribute') to compare. |
| right | [Bb.ComponentModel.Attributes.PriorityAttribute](#T-Bb-ComponentModel-Attributes-PriorityAttribute 'Bb.ComponentModel.Attributes.PriorityAttribute') | The second [PriorityAttribute](#T-Bb-ComponentModel-Attributes-PriorityAttribute 'Bb.ComponentModel.Attributes.PriorityAttribute') to compare. |

<a name='M-Bb-ComponentModel-Attributes-PriorityAttribute-op_LessThan-Bb-ComponentModel-Attributes-PriorityAttribute,Bb-ComponentModel-Attributes-PriorityAttribute-'></a>
### op_LessThan(left,right) `method`

##### Summary

Determines whether the priority of one [PriorityAttribute](#T-Bb-ComponentModel-Attributes-PriorityAttribute 'Bb.ComponentModel.Attributes.PriorityAttribute') is less than another.

##### Returns

`true` if the priority of `left` is less than `right`; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| left | [Bb.ComponentModel.Attributes.PriorityAttribute](#T-Bb-ComponentModel-Attributes-PriorityAttribute 'Bb.ComponentModel.Attributes.PriorityAttribute') | The first [PriorityAttribute](#T-Bb-ComponentModel-Attributes-PriorityAttribute 'Bb.ComponentModel.Attributes.PriorityAttribute') to compare. |
| right | [Bb.ComponentModel.Attributes.PriorityAttribute](#T-Bb-ComponentModel-Attributes-PriorityAttribute 'Bb.ComponentModel.Attributes.PriorityAttribute') | The second [PriorityAttribute](#T-Bb-ComponentModel-Attributes-PriorityAttribute 'Bb.ComponentModel.Attributes.PriorityAttribute') to compare. |

<a name='M-Bb-ComponentModel-Attributes-PriorityAttribute-op_LessThanOrEqual-Bb-ComponentModel-Attributes-PriorityAttribute,Bb-ComponentModel-Attributes-PriorityAttribute-'></a>
### op_LessThanOrEqual(left,right) `method`

##### Summary

Determines whether the priority of one [PriorityAttribute](#T-Bb-ComponentModel-Attributes-PriorityAttribute 'Bb.ComponentModel.Attributes.PriorityAttribute') is less than or equal to another.

##### Returns

`true` if the priority of `left` is less than or equal to `right`; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| left | [Bb.ComponentModel.Attributes.PriorityAttribute](#T-Bb-ComponentModel-Attributes-PriorityAttribute 'Bb.ComponentModel.Attributes.PriorityAttribute') | The first [PriorityAttribute](#T-Bb-ComponentModel-Attributes-PriorityAttribute 'Bb.ComponentModel.Attributes.PriorityAttribute') to compare. |
| right | [Bb.ComponentModel.Attributes.PriorityAttribute](#T-Bb-ComponentModel-Attributes-PriorityAttribute 'Bb.ComponentModel.Attributes.PriorityAttribute') | The second [PriorityAttribute](#T-Bb-ComponentModel-Attributes-PriorityAttribute 'Bb.ComponentModel.Attributes.PriorityAttribute') to compare. |

<a name='T-Bb-ComponentModel-PriorityHelper'></a>
## PriorityHelper `type`

##### Namespace

Bb.ComponentModel

##### Summary

Provides helper methods for working with priority attributes.

<a name='M-Bb-ComponentModel-PriorityHelper-OrderByPriority-System-Collections-Generic-IEnumerable{System-Type}-'></a>
### OrderByPriority(types) `method`

##### Summary

Sorts a list of types by their priority values.

##### Returns

An enumerable collection of types sorted by priority.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| types | [System.Collections.Generic.IEnumerable{System.Type}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{System.Type}') | The list of types to sort. |

##### Example

```C#
var sortedTypes = types.OrderByPriority();
```

##### Remarks

This method uses the [PriorityAttribute](#T-Bb-ComponentModel-Attributes-PriorityAttribute 'Bb.ComponentModel.Attributes.PriorityAttribute') to determine the priority of each type.

<a name='T-Bb-ComponentModel-Attributes-ProviderListBase`1'></a>
## ProviderListBase\`1 `type`

##### Namespace

Bb.ComponentModel.Attributes

##### Summary

Provides a base class for implementing list providers with generic support.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The type of the items in the list. |

<a name='P-Bb-ComponentModel-Attributes-ProviderListBase`1-Instance'></a>
### Instance `property`

##### Summary

Gets or sets the instance of the object that contains the associated property.

##### Remarks

This property is used to access the object that owns the property being managed by the list provider.

<a name='P-Bb-ComponentModel-Attributes-ProviderListBase`1-Property'></a>
### Property `property`

##### Summary

Gets or sets the property descriptor for the associated property.

##### Remarks

This property represents the metadata for the property that the list provider is associated with.

<a name='M-Bb-ComponentModel-Attributes-ProviderListBase`1-Bb#ComponentModel#DataAnnotations#IListProvider#GetItems'></a>
### Bb#ComponentModel#DataAnnotations#IListProvider#GetItems() `method`

##### Summary

Gets the list of items provided by the list provider as non-generic [ListItem](#T-Bb-ComponentModel-DataAnnotations-ListItem 'Bb.ComponentModel.DataAnnotations.ListItem') objects.

##### Returns

An enumerable collection of [ListItem](#T-Bb-ComponentModel-DataAnnotations-ListItem 'Bb.ComponentModel.DataAnnotations.ListItem') objects.

##### Parameters

This method has no parameters.

<a name='M-Bb-ComponentModel-Attributes-ProviderListBase`1-Bb#ComponentModel#DataAnnotations#IListProvider#GetOriginalValue-Bb-ComponentModel-DataAnnotations-ListItem-'></a>
### Bb#ComponentModel#DataAnnotations#IListProvider#GetOriginalValue(item) `method`

##### Summary

Gets the original value for a specified list item.

##### Returns

The original value associated with the list item.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| item | [Bb.ComponentModel.DataAnnotations.ListItem](#T-Bb-ComponentModel-DataAnnotations-ListItem 'Bb.ComponentModel.DataAnnotations.ListItem') | The list item for which to get the original value. |

<a name='M-Bb-ComponentModel-Attributes-ProviderListBase`1-Compare-Bb-ComponentModel-DataAnnotations-ListItem,System-Object-'></a>
### Compare(left,right) `method`

##### Summary

Compares a list item with a specified value to determine equality.

##### Returns

`true` if the list item and value are considered equal; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| left | [Bb.ComponentModel.DataAnnotations.ListItem](#T-Bb-ComponentModel-DataAnnotations-ListItem 'Bb.ComponentModel.DataAnnotations.ListItem') | The list item to compare. |
| right | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The value to compare against. |

##### Remarks

This method performs a comparison between a list item and a value, supporting various types of comparisons.

<a name='M-Bb-ComponentModel-Attributes-ProviderListBase`1-CreateItem-`0,System-String,System-Object,System-Action{Bb-ComponentModel-DataAnnotations-ListItem{`0}}-'></a>
### CreateItem(instance,display,value,initializer) `method`

##### Summary

Creates a new list item with the specified parameters.

##### Returns

A new [ListItem\`1](#T-Bb-ComponentModel-DataAnnotations-ListItem`1 'Bb.ComponentModel.DataAnnotations.ListItem`1') object.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| instance | [\`0](#T-`0 '`0') | The instance of the item. |
| display | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The display text for the item. |
| value | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The value associated with the item. |
| initializer | [System.Action{Bb.ComponentModel.DataAnnotations.ListItem{\`0}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{Bb.ComponentModel.DataAnnotations.ListItem{`0}}') | An optional initializer action to configure the item. |

##### Remarks

This method creates a new list item and optionally initializes it using the provided initializer action.

<a name='M-Bb-ComponentModel-Attributes-ProviderListBase`1-GetItems'></a>
### GetItems() `method`

##### Summary

Gets the list of items provided by the list provider.

##### Returns

An enumerable collection of [ListItem\`1](#T-Bb-ComponentModel-DataAnnotations-ListItem`1 'Bb.ComponentModel.DataAnnotations.ListItem`1') objects.

##### Parameters

This method has no parameters.

##### Remarks

This method must be implemented by derived classes to provide the list of items.

<a name='M-Bb-ComponentModel-Attributes-ProviderListBase`1-GetValue'></a>
### GetValue() `method`

##### Summary

Gets the current value of the associated property.

##### Returns

The current value of the property, or `null` if the value is not set.

##### Parameters

This method has no parameters.

##### Remarks

This method retrieves the value of the property from the associated object instance.

<a name='M-Bb-ComponentModel-Attributes-ProviderListBase`1-ResolveOriginalValue-Bb-ComponentModel-DataAnnotations-ListItem{`0}-'></a>
### ResolveOriginalValue(item) `method`

##### Summary

Resolves the original value for a specified list item.

##### Returns

The original value associated with the list item.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| item | [Bb.ComponentModel.DataAnnotations.ListItem{\`0}](#T-Bb-ComponentModel-DataAnnotations-ListItem{`0} 'Bb.ComponentModel.DataAnnotations.ListItem{`0}') | The list item for which to resolve the original value. |

##### Remarks

This method can be overridden to customize how the original value is resolved for a list item.

<a name='T-Bb-ComponentModel-RefreshEventArgs'></a>
## RefreshEventArgs `type`

##### Namespace

Bb.ComponentModel

##### Summary

Provides data for refresh events.

##### Remarks

This class is used to specify the objects that need to be refreshed during a refresh event.

<a name='M-Bb-ComponentModel-RefreshEventArgs-#ctor-System-Object[]-'></a>
### #ctor(toRefresh) `constructor`

##### Summary

Initializes a new instance of the [RefreshEventArgs](#T-Bb-ComponentModel-RefreshEventArgs 'Bb.ComponentModel.RefreshEventArgs') class with the specified objects to refresh.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| toRefresh | [System.Object[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object[] 'System.Object[]') | The objects that need to be refreshed. |

##### Example

```C#
var args = new RefreshEventArgs(obj1, obj2);
if (args.MustRefresh(obj1))
{
    // Perform refresh logic
}
```

<a name='M-Bb-ComponentModel-RefreshEventArgs-MustRefresh-System-Object-'></a>
### MustRefresh(o) `method`

##### Summary

Determines whether the specified object must be refreshed.

##### Returns

`true` if the object must be refreshed; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| o | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The object to check. |

##### Example

```C#
if (args.MustRefresh(obj))
{
    // Perform refresh logic
}
```

<a name='T-Bb-ComponentModel-Attributes-StepNumericAttribute'></a>
## StepNumericAttribute `type`

##### Namespace

Bb.ComponentModel.Attributes

##### Summary

Specifies a numeric step value for a property.

##### Remarks

This attribute is used to define a step increment for numeric properties, typically for UI or validation purposes.

<a name='M-Bb-ComponentModel-Attributes-StepNumericAttribute-#ctor-System-Single-'></a>
### #ctor(step) `constructor`

##### Summary

Initializes a new instance of the [StepNumericAttribute](#T-Bb-ComponentModel-Attributes-StepNumericAttribute 'Bb.ComponentModel.Attributes.StepNumericAttribute') class with the specified step value.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| step | [System.Single](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Single 'System.Single') | The step increment value for the property. |

##### Example

```C#
[StepNumeric(0.5f)]
public float Increment { get; set; }
```

<a name='P-Bb-ComponentModel-Attributes-StepNumericAttribute-Step'></a>
### Step `property`

##### Summary

Gets the step increment value for the property.

##### Returns

The step increment value.

<a name='T-Bb-ComponentModel-TypeDescriptorExtension'></a>
## TypeDescriptorExtension `type`

##### Namespace

Bb.ComponentModel

##### Summary

Extension for [TypeDescriptor](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ComponentModel.TypeDescriptor 'System.ComponentModel.TypeDescriptor')

<a name='M-Bb-ComponentModel-TypeDescriptorExtension-GetAttributes``1-System-Type-'></a>
### GetAttributes\`\`1(self) `method`

##### Summary

Use type descriptor GetAttribute for resolve the list of attribute

##### Returns

[IEnumerable\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable`1 'System.Collections.Generic.IEnumerable`1')List of attribute

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | Type source |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Type of the attributes you must looking for |

<a name='M-Bb-ComponentModel-TypeDescriptorExtension-GetAttributes``1-System-Type,System-Func{``0,System-Boolean}-'></a>
### GetAttributes\`\`1(self,filterFunction) `method`

##### Summary

Use type descriptor GetAttribute for resolve the list of attribute

##### Returns

[IEnumerable\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable`1 'System.Collections.Generic.IEnumerable`1')List of attribute

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | Type source |
| filterFunction | [System.Func{\`\`0,System.Boolean}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,System.Boolean}') | Type source |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Type of the attributes you must looking for |

<a name='M-Bb-ComponentModel-TypeDescriptorExtension-GetAttributes``1-System-Reflection-PropertyInfo-'></a>
### GetAttributes\`\`1(self) `method`

##### Summary

Use type descriptor GetAttribute for resolve the list of attribute

##### Returns

[IEnumerable\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable`1 'System.Collections.Generic.IEnumerable`1')List of attribute

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [System.Reflection.PropertyInfo](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.PropertyInfo 'System.Reflection.PropertyInfo') | Type source |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Type of the attributes you must looking for |

<a name='M-Bb-ComponentModel-TypeDescriptorExtension-GetAttributes``1-System-Reflection-PropertyInfo,System-Func{``0,System-Boolean}-'></a>
### GetAttributes\`\`1(self,filterFunction) `method`

##### Summary

Use type descriptor GetAttribute for resolve the list of attribute

##### Returns

[IEnumerable\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable`1 'System.Collections.Generic.IEnumerable`1')List of attribute

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [System.Reflection.PropertyInfo](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.PropertyInfo 'System.Reflection.PropertyInfo') | Type source |
| filterFunction | [System.Func{\`\`0,System.Boolean}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,System.Boolean}') | Type source |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Type of the attributes you must looking for |

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
