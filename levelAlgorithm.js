let level = 1;
let baseExp = 100;
let factor = 1.4;

let rankOneKill = 10;
let rankTwoKill = 50;
let rankThreeKill = 100;
let rankFourKill = 250;
let rankFiveKill = 500;
let rankSixKill = 1000;

let totalExp = 0;

var player = {};

for (let i = 0; i < 100; i++) {
    let expToLevel = Math.floor(baseExp * (Math.pow(level, factor)));
    
    player[`Level: ${level}`] = {
        'Total Exp': totalExp,
        'Exp To Level': expToLevel,
        'Rank 1 Kills': Math.round(expToLevel/rankOneKill),
        'Rank 2 Kills': Math.round(expToLevel/rankTwoKill),
        'Rank 3 Kills': Math.round(expToLevel/rankThreeKill),
        'Rank 4 Kills': Math.round(expToLevel/rankFourKill),
        'Rank 5 Kills': Math.round(expToLevel/rankFiveKill),
        'Rank 6 Kills': Math.round(expToLevel/rankSixKill),
    }
    level++;
    totalExp += expToLevel;
}

console.log(" --- Level Chart --- ");
console.table(player);