//BotCU developed for BCU gamestechchat
//For CST Module of BCUGamesTech
//developed by Ben Sturland

var Version = 'V:0.3';

const Discord = require('discord.js');
const client = new Discord.Client();
const math = Math;
var register;

//Makes commands be recoginsed using tild
function commandIs(str, msg){
    return msg.content.toLowerCase().startsWith("`" +str);
}


//when bot is on
client.on('ready', () => {
    console.log('BotCU', Version, 'Now In Java Script!!! ');
    console.log('Created By Ben Sturland');
    console.log('         #            ') ;   
    console.log('  ######     ###      ');
    console.log('#### ##     ###       ');
    console.log('  ######   #          ')
    console.log('   #####    #    ###   ');
    console.log('  # ######   # ##   #  ');
    console.log('   ### #               ');
    console.log('   #### #       #   #  ');
    console.log('  ##### ############   ');
    console.log('  ###### ##########    ');
    console.log('   ################    ');
    console.log('   # ##  ##########    ');
    console.log('    ### ; #########+   ');
    console.log('     ## +#  ### ####   ');
    console.log('    # #     #### ####  ');
    console.log('    # #      ##     #  ');
    console.log('    ###      +#     #  ');
    console.log('     #       ##     ## ');
    console.log(' # ###     ###     ##  ');
    console.log('The Bot Is Online!');
});

//when bot is on run this
client.on('message', message =>{

    var args = message.content.split(/[ ]+/);

    //Adding commands
    // if(commandIs(' ',message)){}

    var Greeting = ["Hello", "Hi", "Top O' The Morning", "Wazz up"];
    if(commandIs('hello', message)){
        var GreetRand = Greeting[Math.floor(Math.random() * Greeting.length)];
        message.channel.sendMessage(GreetRand +message.author.username);
    }

    if(commandIs('reply', message)){
        message.reply('like this?');
    }

    if(commandIs('roll', message)){
        console.log('Command Recived');
        Sides = Number = parseInt(args[0], 10);  
        var Diceroll = (Math.floor(Math.random() * 6) + 1);
        console.log(Diceroll);
        message.reply('Rolled a '+ Diceroll);
    }

});

//Auth Code to log in is bot
client.login('');