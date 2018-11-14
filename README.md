# Integration Project

One Paragraph of project description goes here

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See deployment for notes on how to deploy the project on a live system.

### Prerequisites

What things you need to install the software and how to install them

```
Give examples
```

### Installing

You will need to create a file ``Models/ApiKeys.cs`` in which you define 

```
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_Project.Models
{
    public static class ApiKeys
    {
        public const string geocodeKey = "YOUR_KEY_HERE";
        public const string googleMapsKey = "YOUR_KEY_HERE";
        public static string sendgridKey = "YOUR_KEY_HERE";
    }
}
```

## Running the tests

Explain how to run the automated tests for this system

### Break down into end to end tests

Explain what these tests test and why

```
Give an example
```

### And coding style tests

Explain what these tests test and why

```
Give an example
```

## Deployment

Add additional notes about how to deploy this on a live system

## Built With

* [Dropwizard](http://www.dropwizard.io/1.0.2/docs/) - The web framework used
* [Maven](https://maven.apache.org/) - Dependency Management
* [ROME](https://rometools.github.io/rome/) - Used to generate RSS Feeds

## Contributing

Please read [CONTRIBUTING.md](https://gist.github.com/PurpleBooth/b24679402957c63ec426) for details on our code of conduct, and the process for submitting pull requests to us.

## Versioning

We use [SemVer](http://semver.org/) for versioning. For the versions available, see the [tags on this repository](https://github.com/your/project/tags). 

## Authors

* **Billie Thompson** - *Initial work* - [PurpleBooth](https://github.com/PurpleBooth)

See also the list of [contributors](https://github.com/your/project/contributors) who participated in this project.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

## Acknowledgments

* Hat tip to anyone whose code was used
* Inspiration
* etc

## APIs

API | Function | License
----|----------|--------
[Korzh EasyQuery Linq 4.3.1](https://www.nuget.org/packages/Korzh.EasyQuery.Linq/4.3.1) | Search Database | ?
[SendGrid](https://sendgrid.com/docs/API_Reference/api_v3.html) | Send Emails | [MIT](https://github.com/sendgrid/sendgrid-csharp/blob/master/LICENSE.txt)
[Raty](https://www.jqueryscript.net/other/Full-featured-Star-Rating-Plugin-For-jQuery-Raty.html) | User Ratings | [MIT](https://github.com/wbotelhos/raty/blob/master/LICENSE)
[Yahoo Weather](https://developer.yahoo.com/weather) | Weather | [Yahoo API](https://developer.yahoo.com/attribution)
[Stripe](https://stripe.com/docs/api) | | ?
