function atmMachine(input) {

    let totalCashInATM = [];

    for (let commandArray of input) {

        if (commandArray.length > 2) {
            insert(commandArray);
        } else if (commandArray.length === 2) {

            let [currentBalance, moneyToWithdraw] = commandArray;

            if (currentBalance < moneyToWithdraw) {
                console.log(`Not enough money in your account. Account balance: ${currentBalance}$.`)
            }
            else {
                withdraw(currentBalance, moneyToWithdraw);
            }
        } else if (commandArray.length === 1) {
            report(commandArray[0]);
        }
    }

    function report(banknote){
        let count = totalCashInATM.filter(b => b === banknote).length;
        console.log(`Service Report: Banknotes from ${banknote}$: ${count}.`)
    }

    function withdraw(balance, withdraw) {
        if (withdraw > getSum(totalCashInATM)) {
            console.log('ATM machine is out of order!')
        } else {
            totalCashInATM = totalCashInATM.sort((a, b) => b - a);

            let sum = 0;

            for (let i = 0; i < totalCashInATM.length; i++) {
                if (sum === withdraw) {
                    break;
                }
                if (sum + totalCashInATM[i] <= withdraw) {
                    sum += +totalCashInATM.splice(i, 1);
                    i--;
                }                      
            }  

            console.log(`You get ${sum}$. Account balance: ${balance - sum}$. Thank you!`)
        }
    }

    function getSum(banknotes) {
        return banknotes.reduce((a, b) => a + b, 0);
    }

    function insert(banknotes) {
        totalCashInATM.push(...banknotes);
        console.log(`Service Report: ${getSum(banknotes)}$ inserted. Current balance: ${getSum(totalCashInATM)}$.`)
    }
}

atmMachine([
    [20, 5, 100, 20, 1],
    [457, 25],
    [1],
    [10, 10, 5, 20, 50, 20, 10, 5, 2, 100, 20],
    [20, 85],
    [5000, 4500],
])