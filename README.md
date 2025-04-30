A sort of sample project displaying basic MVVM design philosophy for a WPF project.
It is created mostly for my own purposes but also works a general-use for MVVM projects to template from.

Context:
In the Traveller Table-top RPG, more specifically the Mongoose 2022 Update rulebook, players can, in their downtime, work on trade to generate wealth for their group and company. This involves a lot of dice rolls for the referee / game master to set up and so I made this tool to simplify the process.
It is not in a finished state but the functionality works.

I have elected to use to the CommunityToolkit MVVM nuget package to do the job of providing a base view model to inherit from for the purpose of keeping properties set up with PropertyChanged so data can update in runtime in the view.
