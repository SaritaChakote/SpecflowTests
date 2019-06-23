Feature: SpecFlowFeature2
	In order to update my profile 
	As a skill trader
	I want to add the skills that I know
	
@mytag
Scenario: Check if user could able to add new skills
	Given I clicked on the Skills tab on profile page
	When I add a new Skill
	Then that skill should be displayed on my Skills under my profile
