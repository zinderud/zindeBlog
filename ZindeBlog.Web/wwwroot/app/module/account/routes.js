"use strict";
var router_1 = require('@angular/router');
var account_component_1 = require('./account.component');
var login_component_1 = require('./login.component');
var register_component_1 = require('./register.component');
exports.accountRoutes = [
    {
        path: 'account',
        component: account_component_1.AccountComponent,
        children: [
            { path: 'register', component: register_component_1.RegisterComponent },
            { path: 'login', component: login_component_1.LoginComponent }
        ]
    }
];
exports.accountRouting = router_1.RouterModule.forChild(exports.accountRoutes);
//# sourceMappingURL=routes.js.map