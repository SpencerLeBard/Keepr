## Keepr

- [Figma Document](https://www.figma.com/file/Uui3335TxIEXWzgp4xrX9r/Keepr?node-id=0%3A1)
- [Figma Prototype](https://www.figma.com/proto/Uui3335TxIEXWzgp4xrX9r/Keepr?node-id=1%3A53&scaling=min-zoom)

# Requirements

### Todo:

- View Count - server side in repo/setActiveId
- Delete `keeps` from `vault`s

### Wednesday

- profile page adheres to mock
- Total `keep`s count , anytime a `keep` is `kept in a vault` the keep count is incremented
- Total public `vault`s count

### Pretty much done:

- All deletes require confirmation
- See keeps created by that user in profile (only logged in user works) only gets keeps after get request?
- in vault page if user is creator they can remove keep from vault
- profile has private vaults - request fails if private (fires on mounted)

X - All API Tests pass
