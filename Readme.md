## Keepr

- [Figma Document](https://www.figma.com/file/Uui3335TxIEXWzgp4xrX9r/Keepr?node-id=0%3A1)
- [Figma Prototype](https://www.figma.com/proto/Uui3335TxIEXWzgp4xrX9r/Keepr?node-id=1%3A53&scaling=min-zoom)

# Requirements

### Todo:

- View Count - server side in repo/setActiveId

### Tuesday:

-- dropdown of vaults to select
-- modal disapears

**SQL foreign key issue**

- Create `vaultkeeps`
- Add `keeps`to `vault`
- Delete `keeps` from `vault`s

### Wednesday

- profile page adheres to mock
- private vaults - request fails if private **cannot see private vaults**
- Total `keep`s count , anytime a `keep` is `kept in a vault` the keep count is incremented
- Total public `vault`s count

### Pretty much done:

- All deletes require confirmation
- Keeps created by that user (only logged in user works) only gets keeps after get request?
- in vault page if user is creator they can remove keep from vault
- Users can only Delete things they created

X - All API Tests pass
