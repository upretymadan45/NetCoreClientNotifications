# NetCoreClientNotifications
# Give feedback to client in your asp net core 2 and above mvc application using client side javascript notifications : toastr and sweet js
Installation

From Dotnet CLI
* dotnet add package ClientNotifications --version 1.17.1

From Package Manager
* Install-Package ClientNotifications -Version 1.17.1

Add Client side javascript and css file: 
* Include Toastr js for toast notifications : http://codeseven.github.io/toastr/
* Include Sweet js for sweet notifications : https://lipis.github.io/bootstrap-sweetalert/

Usage:

Add the following to your startup.cs file
* services.AddToastNotification();
  
* Inject IClientNotification to your controller

      private IClientNotification _clientNotification;
              public HomeController(IPetRepository petRepository,
                                      UserManager<Owner> userManager,
                                      INotificationRepository notificationRepository,
                                      IClientNotification clientNotification)
              {
                  _petRepository = petRepository;
                  _userManager = userManager;
                  _clientNotification = clientNotification;
              }
* Create Toast Notification as follows              
        
        _clientNotification.AddToastNotification("From Index of home",
                                                NotificationType.success,
                                                new ToastNotificationOption{
                                                    ProgressBar = true,
                                                    PositionClass ="toast-bottom-right"
                                                });
OR
                                                
        _clientNotification.AddToastNotification("From Index of home",
                                                NotificationType.success,
                                                null);
                                                
* Create Sweet Notifications as follows
                                                
      _clientNotification.AddSweetNotification("Good",
                                        "You have got a success",
                                        NotificationType.success);
                                        

* Add the following line to your layout file 
     @await Component.InvokeAsync("ClientNotifications.Notify")
