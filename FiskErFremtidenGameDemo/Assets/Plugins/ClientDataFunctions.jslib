mergeInto(LibraryManager.library, {
 
   SendLeaderboard: function (value) {
       console.log("SENDING LEADERBOARD DATA");
       console.log(value);
       try{
        GLOBAL.DotNetReference.invokeMethodAsync("LeaderboardData", value);
       }
       catch (e) {
         console.error(e);
       }
   },
 
 });