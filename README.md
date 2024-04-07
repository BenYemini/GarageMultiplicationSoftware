# Garage Multiplication Software🚗💻

Welcome to the Garage Multiplication Software project! This project was developed as part of an intensive course on "Object-oriented programming in the .NET environment & the C# language". It serves as a comprehensive solution for managing garage operations efficiently.

## Overview

The project is structured around several key components, each fulfilling a specific role in the software's architecture. Here's a brief overview of the main components:

- **SessionExecutor**: A public class serving as a client session shell, orchestrating all user interactions and executing various functions provided during the session.

- **Garage**: A public class encapsulating the garage object and providing a rich API for performing garage operations through session execution.

- **UserInterface**: A public class offering APIs for presenting content to the user within the SessionExecutor and handling user inputs via HandleIO.

- **HandleIO**: A public class responsible for validating and handling user inputs, ensuring data integrity throughout session execution.

- **InputValidityChecks**: A public class housing input validity checks, ensuring that user inputs meet specified criteria.

- **ValueOutOfRangeException**: A custom exception class constructed and thrown during input validation checks when values fall outside acceptable ranges.

- **GarageCarCard**: A class holding car card objects within the garage, featuring relevant fields for efficient management.

- **Wheel**: A class containing objects representing vehicle wheels, providing specific actions for wheel management.

- **Engine**: A class serving as a parent class for electric and fuel engines, encapsulating common functionality and behaviors.

- **ElectricEngine & FuelEngine**: Subclasses of Engine, each representing specific engine types and providing operations tailored to their respective functionalities.

- **VehiclesObjectCreation**: A class responsible for building vehicle objects, offering an API to facilitate session execution.

- **GarageDictionaries & eNumsForGarage**: Helper classes providing APIs for configuring various objects and enums used across the project.

- **Car, Motorcycle, Truck**: Classes representing different vehicle types, each containing relevant fields and functionalities specific to their type.

- **Program**: A class containing the main function responsible for initiating the client session using SessionExecutor.

## Project Context🌟

This project is a testament to the principles of object-oriented programming, emphasizing concepts such as readability, scalability, and maintainable code. Throughout the development process, I strived to adhere to these principles, ensuring that the software's architecture promotes modularity, encapsulation, and code reuse.

By leveraging the power of object-oriented design, this project demonstrates the ability to model real-world entities effectively, manage complex interactions between components, and provide a flexible and extensible solution for garage management.

## Conclusion🎉

The Garage Multiplication Software project represents a culmination of knowledge and skills acquired during the course, showcasing proficiency in object-oriented programming paradigms and best practices.

Feel free to explore the project further and contribute to its ongoing development. Your feedback and suggestions are always welcome!

Thank you for your interest in the Garage Multiplication Software project. 

Happy coding! 🚗💻
