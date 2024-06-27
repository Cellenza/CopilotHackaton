##

# Prerequisites

Java 21
Maven 3.5.0 

# Getting Started

Clone the repository to your local machine:

git clone https://github.com/yourusername/your-repo-name.git

Navigate into the project directory:

# Building the Project

Initialize the project :

mvn archetype:generate -DgroupId=com.training.app -DartifactId=my-app -DarchetypeArtifactId=maven-archetype-quickstart -DinteractiveMode=false

mvn clean: Clears the target directory where Maven normally builds your project.

mvn install: Builds the project described by your Maven POM file and installs the resulting artifact (JAR)

mvn compile : Compile sources

# Run the project

Execute Run from VS Code or your favorite IDE

# Running Tests

This project uses JUnit Jupiter for testing. To run the tests, use the following command:

mvn test

# Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.