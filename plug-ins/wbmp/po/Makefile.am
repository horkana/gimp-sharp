## Process this file with automake to produce Makefile.in

AUTOMAKE_OPTIONS = gnu

SHELL=/bin/sh

PLUGIN = wbmp

LINGUAS = it en ru fr he

POFILES = $(shell for lang in $(LINGUAS); do printf "$$lang.po "; done)

CATALOGS = $(shell for lang in $(LINGUAS); do printf "$$lang.mo "; done) 

MSGFMT = msgfmt
GMSGFMT = msgfmt

GMOFILES = $(CATALOGS) 
MOFILES = $(CATALOGS) 

CLEANFILES = $(CATALOGS)

SUFFIXES = .po .gmo .mo

EXTRA_DIST = $(POFILES)

.po.mo:
	$(GMSGFMT) -o $@ $<

all: $(GMOFILES)

