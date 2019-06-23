Feature: ShareSkill page
	In order to add skill on shareskill page

@mytag
Scenario: Add skill on Share Skill page
	Given I have logged in to skillswap.
	And I added my profile 
	When I am adding new skill on share skill page
	Then The skill should get added on Managed listing page
