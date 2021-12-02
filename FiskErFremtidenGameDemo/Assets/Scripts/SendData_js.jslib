mergeInto(LibraryManager.library, {

   SendLeaderboard: function (score) {
       try{
        GLOBAL.DotNetReference.invokeMethodAsync("SetPlayerScoreData", score);
       }
       catch (e) {
         console.error(e);
       }
   },

   SendPlayerChoice: function (animalName) {
       try{
         console.log(Pointer_stringify(animalName));
          GLOBAL.DotNetReference.invokeMethodAsync("SetPlayerAnimalChoiceData", Pointer_stringify(animalName));
       }
       catch (e) {
         console.error(e);
       }
   }

 });