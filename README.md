# CurlingChallenge

In case you would like to test with static x and disc number 6 and radius 2
you can uncomment 31 line in Startup.cs and comment 32 line.

```
public void ConfigureServices(IServiceCollection services)
		{
			services.AddScoped<ICurlingService, CurlingService>();
			services.AddScoped<IDiscPlacementStrategy, CarolDiscPlacementStrategy>();
			//services.AddSingleton<IXCoordinateGenerator, XCoordinateGeneratorWithStaticOutput>(); //for testing static results
			services.AddSingleton<IXCoordinateGenerator, XCoordinateGenerator>(); //original random generator
			services.AddControllersWithViews();
			// In production, the Angular files will be served from this directory
			services.AddSpaStaticFiles(configuration =>
			{
				configuration.RootPath = "ClientApp/dist";
			});
		} 
```
	