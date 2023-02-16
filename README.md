# Route66.WPF.Controls
> Use [README Syntax](https://www.makeareadme.com) to fill this document.

## Summary
- **Route66.WPF.Controls** is a WPF library controls pack.

## License
> This project is under [MIT License](https://choosealicense.com/licenses/mit).

## List of controls
- WrapGridPanel

### WrapGridPanel
Positions child elements in sequential position from left to right, 
breaking content to the next line at the edge of the containing box. 
Subsequent ordering happens sequentially from top to bottom.

This panel was inspired by Bootstrap Grid system.
By default Botstrap devide available area to 12 columns
and force to define width as number of column span.
This lead to fixed percentage values:
- 1 = 1/12 = 8,333...%
- 2 = 2/12 = 1/6 = 16,666...%
- 3 = 3/12 = 1/4 = 25%
- 4 = 4/12 = 1/3 = 33,333...%
- 5 = 5/12 = 41,666...%
- 6 = 6/12 = 1/2 = 50%
- etc

- Example of Bootstrap Grid system HTML class
```html
class="col-sm-1"
class="col-md-2"
class="col-lg-6"
class="col-xl-12"
```

Instead of this it is possoble to assign width as percentage.

- WPF:
```c#
rg:WrapGridPanel.XS="100"
rg:WrapGridPanel.SM="80"
rg:WrapGridPanel.MD="60"
rg:WrapGridPanel.LG="40"
```

