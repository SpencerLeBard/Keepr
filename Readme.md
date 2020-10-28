## Keepr

- [Figma Document](https://www.figma.com/file/Uui3335TxIEXWzgp4xrX9r/Keepr?node-id=0%3A1)
- [Figma Prototype](https://www.figma.com/proto/Uui3335TxIEXWzgp4xrX9r/Keepr?node-id=1%3A53&scaling=min-zoom)

# Requirements

### Wednesday Night 1:

- Remove `keeps` from `vault`s
- in vault page if user is creator they can remove keep from vault
- profile has private vaults - request fails if private (fires on mounted)

### Wednesday Night 2:

- View Count - server side in repo/setActiveId
- Total `keep`s count , anytime a `keep` is `kept in a vault` the keep count is incremented

### Thursday:

- navigate to profile not special page
- Total public `vault`s count

### Pretty much done:

X - All API Tests pass:
failed tests:
-Auth: edit keep by id, delete vault keep, get private vault, get vault , get keepby id
keeps: edit keep by id
vault: get private vault
vaultkeep: delete vaultkeep
