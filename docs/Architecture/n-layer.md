# N-Layer

We use the N-Layer application architecture which consists in splitting the application into several layers

## Explanations of the layers

### Présentation
The Presentation layer represents the views of the application.

### Application
The role of the Application layer is to make calls to different services. It collects the responses from the services.

### Domain
The Domain layer is the business layer, this is where our business objects will be. It is, more generally, the logical layer of our application. This layer has been divided in two to be able to isolate more strongly. More specifically, this allows us to isolate the "Services" classes from their interfaces. The thinking behind this is mainly to isolate the dependencies of the "Services" classes. This allows an external class wishing to access the interfaces not to have, by chaining, the dependencies associated with the "Services".

### DTO
The DTO layer contains the DTO objects. A DTO object is a data transfer object that contains no business logic.

### Infrastructure
The Infrastructure layer is the data access layer. In our case, it is in this layer that we access the templates of our generation.

### Transport
The role of the Transport layer is to receive requests. In our case, it is in this layer that we have the controllers that receive HTTP requests.

First of all, HTTP is a communication protocol between a client and a server. It allows the establishment of a connection between a computer (client) and a server. HTTP defines a set of request methods indicating the action to be performed on a resource. They are called "HTPP verbs".

Finally, a controller controls how a user interacts with an application. Controllers contain the flow control logic of the application. It determines what response to return when a user makes a browser request. 

This is also the layer where we have our Web API. In our case, our controllers are called endpoints. An endpoint is what we call an end of a communication channel. In other words, when an API interacts with another system, the endpoints of that communication are considered endpoints. 