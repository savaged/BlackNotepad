# ViewModel Testing

Really tough to do due to the heavy use of logic in the Views. 

I believe that the logic in the Views is valid because it leverages
the UI control features that should not appear in the ViewModel.

The 'simpler' route is to create UI tests with something like 
`TestStack.White`.