Feature: RecipeSearch

A short summary of the feature

Scenario: user request viable recipes based on empty pantry
	Given an empty pantry
	When user request for viable recipe
	Then a notification is provided indicating that no viable recipes are found

Scenario: user request viable recipes based on pantry with items
	Given an pantry with
    | Ingrediant | Quanity | Appliances |
    | Apple | 2 | - |
    | - |1 | Blender    |
	When user request for viable recipe
	Then a viable recipe is provided 
