$(() => {
    const app = Sammy('#main', function () {
        this.use('Handlebars', 'hbs');

        this.get("/index.html", displayHome);
        this.get("#/home", displayHome);
        this.get("#/about", displayAbout);
        this.get("#/login", displayLogin);
        this.get("#/register", displayRegister);
        this.get("#/logout", logoutUser);
        this.get("#/catalog", displayCatalog);
        this.get("#/catalog/:id", displayTeamDetails);
        this.get("#/create", displayCreateTeamForm);
        this.get('#/join/:id', joinTeam);
        this.get('#/leave', leaveTeam);
        this.get('#/edit/:id', displayEditForm);
        
        

        this.post("#/register", registerUser);
        this.post("#/login", loginUser);
        this.post("#/create", createTeam);
        this.post("#/edit/:id", editTeam);

        function displayHome(context) {
            context.loggedIn = sessionStorage.getItem("authtoken") !== null;
            context.username = sessionStorage.getItem("username");
            // context.teamId = sessionStorage.getItem("teamId") !== "undefined" && sessionStorage.getItem("teamId") !== null;

            context.loadPartials({
                header: "./templates/common/header.hbs",
                footer: "./templates/common/footer.hbs"
            }).then(function () {
                this.partial("./templates/home/home.hbs")
            });
        }

        function displayAbout(context) {
            context.loggedIn = sessionStorage.getItem("authtoken") !== null;
            context.username = sessionStorage.getItem("username");

            context.loadPartials({
                header: "./templates/common/header.hbs",
                footer: "./templates/common/footer.hbs"
            }).then(function () {
                this.partial("./templates/about/about.hbs")
            })
        }

        function displayLogin(context) {
            context.loggedIn = sessionStorage.getItem("authtoken") !== null;
            context.username = sessionStorage.getItem("username");

            this.loadPartials({
                header: "./templates/common/header.hbs",
                footer: "./templates/common/footer.hbs",
                loginForm: "./templates/login/loginForm.hbs"
            }).then(function () {
                this.partial("./templates/login/loginPage.hbs")
            });
        }

        function displayRegister(context) {
            context.loggedIn = sessionStorage.getItem("authtoken") !== null;
            context.username = sessionStorage.getItem("username");

            this.loadPartials({
                header: "./templates/common/header.hbs",
                footer: "./templates/common/footer.hbs",
                registerForm: "./templates/register/registerForm.hbs"
            }).then(function () {
                this.partial("./templates/register/registerPage.hbs")
            });
        }

        function registerUser(context) {
            let username = this.params.username;
            let password = this.params.password;
            let repeatPassword = this.params.repeatPassword;

            if (password !== repeatPassword) {
                auth.showError("The passwords must match!")
            } else {
                auth.register(username, password)
                    .then(function (userInfo) {
                        auth.saveSession(userInfo);
                        auth.showInfo("Registration Successful");
                        displayHome(context);
                    }).catch(auth.handleError)
            }
        }

        function loginUser(context) {
            let username = this.params.username;
            let password = this.params.password;

            auth.login(username, password)
                .then(function (userInfo) {
                    auth.saveSession(userInfo);
                    auth.showInfo("Login Successful");
                    displayHome(context);
                }).catch(auth.handleError)
        }

        function logoutUser(context) {
            auth.logout()
                .then(function () {
                    sessionStorage.clear();
                    auth.showInfo("Logout Successful");
                    displayHome(context);
                })
        }

        function displayCatalog(context) {
            teamsService.loadTeams()
                .then(function (data) {
                    console.log(data);
                    console.log(context);
                    context.loggedIn = sessionStorage.getItem('authtoken') !== null;
                    context.username = sessionStorage.getItem('username');
                    context.hasTeam = sessionStorage.getItem('teamId') !== null;
                    context.hasNoTeam = sessionStorage.getItem('teamId') === null ||
                        sessionStorage.getItem('teamId') === "undefined";
                    context.teams = data;
                    context.loadPartials({
                        header: './templates/common/header.hbs',
                        footer: './templates/common/footer.hbs',
                        team: './templates/catalog/team.hbs'
                    }).then(function () {
                        this.partial('./templates/catalog/teamCatalog.hbs');
                    });
                });
        }

        function displayTeamDetails(context) {
            let teamId = context.params.id.substr(1);
            teamsService.loadTeamDetails(teamId)
                .then(function (teamInfo) {
                    console.log(teamInfo);
                    console.log(context);
                    context.loggedIn = sessionStorage.getItem('authtoken') !== null;
                    context.username = sessionStorage.getItem('username');
                    context.name = teamInfo.name;
                    context.comment = teamInfo.comment;
                    context.members = teamInfo.members;
                    context.teamId = teamInfo._id;
                    context.isOnTeam = teamInfo._id === sessionStorage.getItem('teamId');
                    context.isAuthor = teamInfo._acl.creator === sessionStorage.getItem('userId');
                    context.loadPartials({
                        header: './templates/common/header.hbs',
                        footer: './templates/common/footer.hbs',
                        teamMember: './templates/catalog/teamMember.hbs',
                        teamControls: './templates/catalog/teamControls.hbs'
                    }).then(function () {
                        this.partial('./templates/catalog/details.hbs');
                    })
                });
        }

        function displayCreateTeamForm(context) {
            this.loadPartials({
                header: "./templates/common/header.hbs",
                footer: "./templates/common/footer.hbs",
                createForm: "./templates/create/createForm.hbs"
            }).then(function () {
                this.partial("./templates/create/createPage.hbs")
            });
        }

        function createTeam(context) {
            let teamName = context.params.name;
            let teamComment = context.params.comment;
            teamsService.createTeam(teamName, teamComment)
                .then(function (teamInfo) {
                    teamsService.joinTeam(teamInfo._id)
                        .then(function (data) {
                            auth.saveSession(data);
                            auth.showInfo('TEAM HAS BEEN JOINED!');
                            displayCatalog(context);
                        });
                })
        }
        function joinTeam(context){
            let teamId = this.params.id.substr(1);
            console.log(teamId);
            teamsService.joinTeam(teamId)
                .then((data) => {
                    auth.saveSession(data);
                    auth.showInfo('TEAM HAS BEEN JOINED!');
                    displayCatalog(context);
                });
        }

        function leaveTeam(context){
             teamsService.leaveTeam()
                 .then(function (response) {
                     auth.saveSession(response);
                     auth.showInfo('TEAM HAS BEEN LEFT!');
                     displayCatalog(context);
                 });
        }

        function displayEditForm(context){
             context.loggedIn = sessionStorage.getItem('authtoken') !== null;
             context.username = sessionStorage.getItem('username');
             context.teamId = this.params.id.substr(1);
             teamsService.loadTeamDetails(context.teamId)
                 .then((teamInfo) => {
                     context.name = teamInfo.name;
                     context.comment = teamInfo.comment;
                     this.loadPartials({
                         header: './templates/common/header.hbs',
                         footer: './templates/common/footer.hbs',
                         editForm: './templates/edit/editForm.hbs'
                     }).then(function () {
                         this.partial('./templates/edit/editPage.hbs');
                     })
                 })
        }
        function editTeam(context){
            let teamId = context.params.id.substr(1);
            let teamName = context.params.name;
            let teamComment = context.params.comment;

            teamsService.edit(teamId, teamName, teamComment)
                .then(function () {
                    auth.showInfo(`TEAM ${teamName} EDITED!`);
                    displayCatalog(ctx);
                })
        }
    });

    app.run();
});