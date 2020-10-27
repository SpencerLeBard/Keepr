import Vue from "vue";
import VueRouter from "vue-router";
// @ts-ignore
import Home from "../pages/Home.vue";
// @ts-ignore
import ProfilePage from "../pages/ProfilePage.vue";
// @ts-ignore
import VaultPage from "../pages/VaultPage";
// @ts-ignore
import MyProfilePage from "../pages/MyProfilePage";

Vue.use(VueRouter);

const routes = [
  {
    path: "/",
    name: "Home",
    component: Home,
  },
  {
    path: "/profiles/:profileId",
    name: "Profile",
    component: ProfilePage,
  },
  {
    path: "/vaults/:vaultId",
    name: "VaultPage",
    component: VaultPage,
  },
  {
    path: "/profiles",
    name: "MyProfilePage",
    component: MyProfilePage,
  }
];

const router = new VueRouter({
  routes,
});

export default router;
