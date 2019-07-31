# TestUiPathSolution
For normal Best Practice Test

Validations

● Variables

->Names should start with a lowercase letter (camelCase)

->Names should not contain accents

● Arguments
->Names should start with direction prefix (e.g. in_)
->Names should start with a capital letter after the underscore (TitleCase)
->Names should not contain accents

● Invoke Workflow
->Invoked workflow file should exist
->All workflow arguments should be present
->No spare arguments should be present
->Arguments should have the same type and direction
->Should avoid invoke recursion (chances of loop cycles)

● Empty scopes
->Flowchart activities should have at least one activity inside
->Sequence activities should have at least one activity inside
->While activities should have at least one activity inside
->Do While activities should have at least one activity inside
->If activities should have at least one activity on either then or else

● Flowchart
->Should not have any disconnected / orphan activities
->Suggests that Flowchart with no decisions or switches should be sequences

● State Machine
->Should not have any disconnected / orphan states
->All non-final states must have an exit and reach a final state

● Try Catch
->Should have at least one activity in the Try section
->Should have at least one activity in either a catch or on the finally section

● Switch
->Should have at least one case besides Default
->Should have at least one activity in each case

● Files
->Files should be invoked (directly or indirectly) from the main file at least once

● Delay
->Should avoid having delays, either as Delay activity or DelayBefore and DelayAfter attributes

● Comments
->Should not have CommentOut activities. If the activity is not being used, it should be removed

Validation results found within CommentOut activities blocks are not returned
 

