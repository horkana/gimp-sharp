## Process this file with automake to produce Makefile.in

all: SliceTool.exe

GIMPSHARPLIB = $(top_builddir)/lib/gimp-sharp.dll

ASSEMBLIES = -r:$(GIMPSHARPLIB) -r:Mono.Posix /pkg:gtk-sharp-2.0 /target:winexe

MYSOURCES =			\
	CellPropertiesFrame.cs	\
	CoordinatesDisplay.cs	\
	CreateFunc.cs		\
	CreateTableFunc.cs	\
	Dialog.cs		\
	FileExistsDialog.cs	\
	Format.cs		\
	HorizontalSlice.cs	\
	JavaScriptProperty.cs	\
	LoadSettingsButton.cs	\
	MouseFunc.cs		\
	MoveSliceFunc.cs	\
	PreferencesButton.cs	\
	PreferencesDialog.cs	\
	Preview.cs		\
	PreviewRenderer.cs	\
	Property.cs		\
	PropertySet.cs		\
	Rectangle.cs		\
	RectangleSet.cs		\
	RemoveFunc.cs		\
	RolloverDialog.cs	\
	RolloverEntry.cs	\
	RolloversFrame.cs	\
	SaveSettingsButton.cs	\
	SelectFunc.cs		\
	Slice.cs		\
	SliceData.cs		\
	SliceSet.cs		\
	SliceTool.cs		\
	TableDialog.cs		\
	Toolbox.cs		\
	VerticalSlize.cs	\
	XmlNodeExtensions.cs

EXTRA_DIST = $(MYSOURCES) 	\
	SliceTool 		\
	SliceTool.png 		\
	blank.png 		\
	stock-arrow.png 	\
	cursor-eraser.png	\
	cursor-select.png	\
	cursor-slice.png	\
	cursor-table.png	\
	javascript.html
SUBDIRS = po

CLEANFILES = SliceTool.exe

SliceTool.exe : $(MYSOURCES) SliceTool.png $(GIMPSHARPLIB)
	$(CSC) $(CSC_FLAGS) $(MYSOURCES) /resource:SliceTool.png	\
			  /resource:blank.png		\
			  /resource:cursor-eraser.png	\
			  /resource:cursor-select.png	\
			  /resource:cursor-slice.png	\
			  /resource:cursor-table.png	\
			  /resource:stock-arrow.png	\
			  /resource:javascript.html	\
		-out:$@ $(ASSEMBLIES)

install:
	$(INSTALL_DATA) SliceTool.exe $(DESTDIR)$(GIMPPLUGINDIR)
	$(INSTALL) SliceTool $(DESTDIR)$(GIMPPLUGINDIR)
	@for lang in `ls po | grep .mo`;\
		do localedir=`echo $$lang | sed -e's/.mo//'`;\
		echo "Copying po/$$lang to $(DESTDIR)$(GIMPLOCALE)/$$localedir/LC_MESSAGES/SliceTool.mo";\
		$(INSTALL_DATA) -d $(DESTDIR)$(GIMPLOCALE)/$$localedir/LC_MESSAGES/;\
		$(INSTALL_DATA) po/$$lang $(DESTDIR)$(GIMPLOCALE)/$$localedir/LC_MESSAGES/SliceTool.mo;\
		done
