<?xml version="1.0"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="xml" indent="yes" encoding="gb2312"/>
  <xsl:template match="/">
    <xsl:element name ="ufinterface">
      <xsl:attribute name ="billtype">WQ</xsl:attribute>
      <xsl:attribute name ="filename"></xsl:attribute>
      <xsl:attribute name ="isexchange">Y</xsl:attribute>
      <xsl:attribute name ="operation">req</xsl:attribute>
      <xsl:attribute name ="proc">add</xsl:attribute>
      <xsl:attribute name ="receiver">101</xsl:attribute>
      <xsl:attribute name ="replace">N</xsl:attribute>
      <xsl:attribute name ="roottag">bill</xsl:attribute>
      <xsl:attribute name ="sender">1104</xsl:attribute>

      <xsl:element name ="bill">
        <xsl:attribute name ="id">
          <xsl:value-of select ="NewDataSet/M/scddh"/>
        </xsl:attribute>
        <xsl:element name ="bill_head">
          <xsl:element name="header">
          <xsl:element name ="scddh">
            <xsl:value-of select="NewDataSet/M/scddh"/>
          </xsl:element>
          <xsl:element name ="vproductbatchcode">
            <xsl:value-of select="NewDataSet/M/vproductbatchcode"/>
          </xsl:element>
          <xsl:element name ="vcheckbillcode">
            <xsl:value-of select="NewDataSet/M/vcheckbillcode"/>
          </xsl:element>
          <xsl:element name ="bcompcheck">
            <xsl:value-of select="NewDataSet/M/bcompcheck"/>
          </xsl:element>
          <xsl:element name ="vbatchcode">
            <xsl:value-of select="NewDataSet/M/vbatchcode"/>
          </xsl:element>
          <xsl:element name ="cpraydeptid">
            <xsl:value-of select="NewDataSet/M/cpraydeptid"/>
          </xsl:element>
          <xsl:element name ="cprayerid">
            <xsl:value-of select="NewDataSet/M/cprayerid"/>
          </xsl:element>
          <xsl:element name ="creporterid">
            <xsl:value-of select="NewDataSet/M/creporterid"/>
          </xsl:element>
          <xsl:element name ="dpraydate">
            <xsl:value-of select="NewDataSet/M/dpraydate"/>
          </xsl:element>
          <xsl:element name ="nchecknum">
            <xsl:value-of select="NewDataSet/M/nchecknum"/>
          </xsl:element>            
            <xsl:element name ="nassistchecknum">
            <xsl:value-of select="NewDataSet/M/nassistchecknum"/>
          </xsl:element>
            <xsl:element name ="cassistunitid">
              <xsl:value-of select="NewDataSet/M/cassistunitid"/>
            </xsl:element>
          <xsl:element name ="cstoreorganization">
            <xsl:value-of select="NewDataSet/M/cstoreorganization"/>
          </xsl:element>
          <xsl:element name ="cpraycorp">
            <xsl:value-of select="NewDataSet/M/cpraycorp"/>
          </xsl:element>
          <xsl:element name ="ccheckbillid">
            <xsl:value-of select="NewDataSet/M/ccheckbillid"/>
          </xsl:element>
          </xsl:element>
          <xsl:element name ="items">
          <xsl:for-each select="NewDataSet/s1">
            <xsl:element name ="item">
              <xsl:element name ="vinvbatchcode">
                <xsl:value-of select ="vinvbatchcode"/>
              </xsl:element>
              <xsl:element name ="ccheckbill_b1id">
                <xsl:value-of select ="ccheckbill_b1id"/>
              </xsl:element>
              <xsl:element name ="dproducedate">
                <xsl:value-of select ="dproducedate"/>
              </xsl:element>
              <xsl:element name ="cbaseid">
                <xsl:value-of select="cbaseid"/>
              </xsl:element>
              <xsl:element name ="cchgbaseid">
                <xsl:value-of select="cchgbasid"/>
              </xsl:element>
              <xsl:element name ="cchgassistunitid">
                <xsl:value-of select="cchgassistunitid"/>
              </xsl:element>
              <xsl:element name ="vdef1">
                <xsl:value-of select="vdef1"/>
              </xsl:element>
              <xsl:element name ="vdef2">
                <xsl:value-of select="vdef2"/>
              </xsl:element>
              <xsl:element name ="vdef3">
                <xsl:value-of select="vdef3"/>
              </xsl:element>
              <xsl:element name ="vdef4">
                <xsl:value-of select="vdef4"/>
              </xsl:element>
              <xsl:element name ="vdef5">
                <xsl:value-of select="vdef5"/>
              </xsl:element>
              <xsl:element name ="vfree1">
                <xsl:value-of select="vfree1"/>
              </xsl:element>
              <xsl:element name ="vfree2">
                <xsl:value-of select="vfree2"/>
              </xsl:element>
              <xsl:element name ="vfree3">
                <xsl:value-of select="vfree3"/>
              </xsl:element>
              <xsl:element name ="vfree4">
                <xsl:value-of select="vfree4"/>
              </xsl:element>
              <xsl:element name ="vfree5">
                <xsl:value-of select="vfree5"/>
              </xsl:element>
              <xsl:element name ="nnum">
                <xsl:value-of select="nnum"/>
              </xsl:element>
              <xsl:element name ="nassistnum">
                <xsl:value-of select="nassistnum"/>
              </xsl:element>
              <xsl:element name ="bcheckin">
                <xsl:value-of select="bcheckin"/>
              </xsl:element>
              <xsl:element name ="bqualified">
                <xsl:value-of select="bqualified"/>
              </xsl:element>
              <xsl:element name ="bchange">
                <xsl:value-of select="bchange"/>
              </xsl:element>
              <xsl:element name ="ccheckstatecode">
                <xsl:value-of select="ccheckstatecode"/>
              </xsl:element>
              <xsl:element name ="ccheckstatename">
                <xsl:value-of select="ccheckstatename"/>
              </xsl:element>
              <xsl:element name ="vmemo">
                <xsl:value-of select="vmemo"/>
              </xsl:element>
              <xsl:element name ="ccheckstate_bid">
                <xsl:value-of select="ccheckstate_bid"/>
              </xsl:element>
            </xsl:element>
          </xsl:for-each>
          </xsl:element>
          <xsl:element name ="b2Items">
            <xsl:for-each select="NewDataSet/s2">
            <xsl:element name ="item">
              <xsl:element name ="cbaseid">
                <xsl:value-of select ="cbaseid"/>
              </xsl:element>
              <xsl:element name ="dcheckdate">
                <xsl:value-of select ="dcheckdate"/>
              </xsl:element>
              <xsl:element name ="vsamplecode">
                <xsl:value-of select="vsamplecode"/>
              </xsl:element>
              <xsl:element name ="nnum">
                <xsl:value-of select="nnum"/>
              </xsl:element>
              <xsl:element name ="ccheckitemid">
                <xsl:value-of select="ccheckitemid"/>
              </xsl:element>
              <xsl:element name ="ccheckstandardid">
                <xsl:value-of select="ccheckstandardid"/>
              </xsl:element>
              <xsl:element name ="icheckstandard">
                <xsl:value-of select="icheckstandard"/>
              </xsl:element>
              <xsl:element name ="cresult">
                <xsl:value-of select="cresult"/>
              </xsl:element>
              <xsl:element name ="ccheckerid">
                <xsl:value-of select="ccheckerid"/>
              </xsl:element>              
            </xsl:element>
          </xsl:for-each>
          </xsl:element>
        </xsl:element>
      </xsl:element>
    </xsl:element>
  </xsl:template>
</xsl:stylesheet>